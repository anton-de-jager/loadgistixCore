import { Component, ViewEncapsulation } from '@angular/core';
import { FuseNavigationItem, FuseNavigationService, FuseVerticalNavigationComponent } from '@fuse/components/navigation';
import { FuseMediaWatcherService } from '@fuse/services/media-watcher';
import { VariableService } from 'app/shared/variable.service';
import { Subject, takeUntil } from 'rxjs';

@Component({
    selector     : 'landing-home',
    templateUrl  : './home.component.html',
    encapsulation: ViewEncapsulation.None
})
export class LandingHomeComponent
{
    isScreenSmall: boolean;
    private _unsubscribeAll: Subject<any> = new Subject<any>();
    navigation: FuseNavigationItem[] = [
        {
            id: 'home',
            title: 'Home',
            type: 'basic',
            icon: 'heroicons_outline:home',
            link: '/home'
        },
        {
            id: 'business-directory',
            title: 'Business Directory',
            type: 'basic',
            icon: 'heroicons_outline:chart-pie',
            link: '/business-directory'
        }
    ]

    slides = [{'image': 'https://wowslider.com/sliders/demo-77/data1/images/road220058.jpg'}, {'image': 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTnzApyh1ZmbXLBUg_iFRio23hzRyAJfwBRfnVozXdEnu-NK4jFt2_gsYujKf-CbT6Cr_A&usqp=CAU'},{'image': 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTdTX3TsFxa8uK4DwS6dstedMHW1E5gYAErjqB8gQNkccBIpVP72e7p8Yg0XatrcuBnn8U&usqp=CAU'}, {'image': 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTmZr_PG6yKkHI-wA6_7lVrX7Hz_ZGY118Oqr1q9pO7TbQk5pvQfLzojf9dtK1dHIhC6yM&usqp=CAU'}, {'image': 'https://therichpost.com/wp-content/uploads/2021/02/angular-11-bootstrap-4.5-Ecommerce-Template-Free.png'}];
    
    constructor(
        private _fuseNavigationService: FuseNavigationService,
        public variableService: VariableService,
        private _fuseMediaWatcherService: FuseMediaWatcherService
    )
    {
    }
    ngOnInit(): void
    {
        // Subscribe to media changes
        this._fuseMediaWatcherService.onMediaChange$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(({matchingAliases}) => {

                // Check if the screen is small
                this.isScreenSmall = !matchingAliases.includes('md');
            });
    }

    toggleNavigation(name: string): void
    {
        // Get the navigation
        const navigation = this._fuseNavigationService.getComponent<FuseVerticalNavigationComponent>(name);

        if ( navigation )
        {
            // Toggle the opened status
            navigation.toggle();
        }
    }
    
    /**
     * Getter for current year
     */
     get currentYear(): number
     {
         return new Date().getFullYear();
     }
}
