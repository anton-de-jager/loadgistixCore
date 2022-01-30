import { NgModule } from '@angular/core';
import { Route, RouterModule } from '@angular/router';
import { BusinessDirectoryComponent } from 'app/modules/admin/pages/business-directory/business-directory.component';

import { SharedModule } from 'app/shared/shared.module';

const businessDirectoryRoutes: Route[] = [
    {
        path     : '',
        component: BusinessDirectoryComponent
    }
];

@NgModule({
    declarations: [
        BusinessDirectoryComponent
    ],
    imports     : [
        RouterModule.forChild(businessDirectoryRoutes),

        SharedModule
    ]
})
export class BusinessDirectoryModule
{
}
