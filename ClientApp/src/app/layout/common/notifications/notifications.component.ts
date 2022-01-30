import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnDestroy, OnInit, TemplateRef, ViewChild, ViewContainerRef, ViewEncapsulation } from '@angular/core';
import { Overlay, OverlayRef } from '@angular/cdk/overlay';
import { TemplatePortal } from '@angular/cdk/portal';
import { MatButton } from '@angular/material/button';
import { Subject, takeUntil } from 'rxjs';
import { Notification } from 'app/layout/common/notifications/notifications.types';
import { NotificationsService } from 'app/layout/common/notifications/notifications.service';
import { MessageService } from 'app/modules/admin/services/message.service';

@Component({
    selector: 'notifications',
    templateUrl: './notifications.component.html',
    encapsulation: ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush,
    exportAs: 'notifications'
})
export class NotificationsComponent implements OnInit, OnDestroy {
    @ViewChild('notificationsOrigin') private _notificationsOrigin: MatButton;
    @ViewChild('notificationsPanel') private _notificationsPanel: TemplateRef<any>;

    notifications: Notification[];
    unreadCount: number = 0;
    private _overlayRef: OverlayRef;
    private _unsubscribeAll: Subject<any> = new Subject<any>();
    newAlert: boolean = false;

    /**
     * Constructor
     */
    constructor(
        private _changeDetectorRef: ChangeDetectorRef,
        private _notificationsService: NotificationsService,
        private _overlay: Overlay,
        private _viewContainerRef: ViewContainerRef,
        private messageService: MessageService
    ) {
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void {
        this.messageService.messages.subscribe(msg => {
            console.log(msg);
            if (msg.userId.toString() == localStorage.getItem('userId')) {
                this._notificationsService.getAll().subscribe(result => {
                    // Load the notifications
                    this.notifications = result;

                    // Calculate the unread count
                    this._calculateUnreadCount();

                    // Mark for check
                    this._changeDetectorRef.markForCheck();

                    this.newAlert = true;

                    setTimeout(() => {
                        this.newAlert = false;
                    }, 1000);
                });
            }
        });
        // Subscribe to notification changes
        this._notificationsService.notifications$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((notifications: Notification[]) => {
                console.log('New Message: ', notifications);

                // Load the notifications
                this.notifications = notifications;

                this.notifications.forEach(notification => {
                    //notification.link = 'loads';
                    notification.useRouter = true;
                });

                // Calculate the unread count
                this._calculateUnreadCount();

                // Mark for check
                this._changeDetectorRef.markForCheck();
            });
        // setInterval(() => {
        //     this._notificationsService.getAll().subscribe(result => {
        //         // Load the notifications
        //         this.notifications = result;

        //         this.notifications.forEach(notification => {
        //             notification.link = '/loads';
        //         });

        //         // Calculate the unread count
        //         this._calculateUnreadCount();

        //         // Mark for check
        //         this._changeDetectorRef.markForCheck();
        //     });
        // }, 120000);
    }

    /**
     * On destroy
     */
    ngOnDestroy(): void {
        // Unsubscribe from all subscriptions
        this._unsubscribeAll.next(null);
        this._unsubscribeAll.complete();

        // Dispose the overlay
        if (this._overlayRef) {
            this._overlayRef.dispose();
        }
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Open the notifications panel
     */
    openPanel(): void {
        // Return if the notifications panel or its origin is not defined
        if (!this._notificationsPanel || !this._notificationsOrigin) {
            return;
        }

        // Create the overlay if it doesn't exist
        if (!this._overlayRef) {
            this._createOverlay();
        }

        // Attach the portal to the overlay
        this._overlayRef.attach(new TemplatePortal(this._notificationsPanel, this._viewContainerRef));
    }

    /**
     * Close the notifications panel
     */
    closePanel(): void {
        this._overlayRef.detach();
    }

    /**
     * Mark all notifications as read
     */
    markAllAsRead(): void {
        // Mark all as read
        this._notificationsService.markAllAsRead().subscribe();
    }

    /**
     * Toggle read status of the given notification
     */
    toggleRead(notification: Notification): void {
        // Toggle the read status
        notification.read = !notification.read;

        // Update the notification
        this._notificationsService.update(notification.id, notification).subscribe();
    }

    /**
     * Delete the given notification
     */
    delete(notification: Notification): void {
        // Delete the notification
        this._notificationsService.delete(notification.id).subscribe();
    }

    /**
     * Track by function for ngFor loops
     *
     * @param index
     * @param item
     */
    trackByFn(index: number, item: any): any {
        return item.id || index;
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Private methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Create the overlay
     */
    private _createOverlay(): void {
        // Create the overlay
        this._overlayRef = this._overlay.create({
            hasBackdrop: true,
            backdropClass: 'fuse-backdrop-on-mobile',
            scrollStrategy: this._overlay.scrollStrategies.block(),
            positionStrategy: this._overlay.position()
                .flexibleConnectedTo(this._notificationsOrigin._elementRef.nativeElement)
                .withLockedPosition(true)
                .withPush(true)
                .withPositions([
                    {
                        originX: 'start',
                        originY: 'bottom',
                        overlayX: 'start',
                        overlayY: 'top'
                    },
                    {
                        originX: 'start',
                        originY: 'top',
                        overlayX: 'start',
                        overlayY: 'bottom'
                    },
                    {
                        originX: 'end',
                        originY: 'bottom',
                        overlayX: 'end',
                        overlayY: 'top'
                    },
                    {
                        originX: 'end',
                        originY: 'top',
                        overlayX: 'end',
                        overlayY: 'bottom'
                    }
                ])
        });

        // Detach the overlay from the portal on backdrop click
        this._overlayRef.backdropClick().subscribe(() => {
            this._overlayRef.detach();
        });
    }

    /**
     * Calculate the unread count
     *
     * @private
     */
    private _calculateUnreadCount(): void {
        let count = 0;

        if (this.notifications && this.notifications.length) {
            count = this.notifications.filter(notification => !notification.read).length;
        }

        this.unreadCount = count;
    }
}
