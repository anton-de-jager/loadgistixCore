import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { FormGroup, Validators } from '@angular/forms';
import { MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatDialog } from "@angular/material/dialog";
import { Subject } from 'rxjs';
import { ApiService } from 'app/modules/admin/services/api.service';
import { DialogAddressComponent } from '../dialog-address/dialog-address.component';
import { DialogCameraComponent } from '../dialog-camera/dialog-camera.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import compress from 'compress-base64';
import { FuseSplashScreenService } from '@fuse/services/splash-screen';

@Component({
    selector: 'dialog-advert',
    templateUrl: 'dialog-advert.component.html'
})
export class DialogAdvertComponent {
    loading: boolean = true;
    form: FormGroup;
    formErrors: any;
    formValid: boolean;
    private _unsubscribeAll: Subject<any>;
    formData: any;
    previewImage: string = null;
    fileToUpload: any;

    constructor(
        private dialog: MatDialog,
        public dialogRef: MatDialogRef<DialogAdvertComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any,
        private _snackBar: MatSnackBar,
        private fuseSplashScreenService: FuseSplashScreenService,
        private apiService: ApiService) {
        this.formErrors = data.formErrors;
        this.formData = data;

        this._unsubscribeAll = new Subject();
    }

    ngOnInit(): void {
        this.form = this.data.form;
        this.formValid = false;
        this.loading = false;
        //this.previewImage = this.form.controls['avatar'].value;
    }

    handleFileInput(file: FileList) {
        this.fileToUpload = file.item(0);
        this.form.controls['fileToUpload'].setValue(this.fileToUpload);
        var size = (this.fileToUpload.size / (1024 * 1024)).toFixed(2);
        if (Number(size) > Number(0.25)) {
            this._snackBar.open('Error: Maximum FileSize is 200kB', null, { duration: 2000 });
            return false;
        } else {

            //Show image preview
            let reader = new FileReader();
            reader.onload = (event: any) => {
                this.previewImage = event.target.result;
            };
            reader.readAsDataURL(this.fileToUpload);
        }
    }

    initCamera() {
        const dialogConfig = new MatDialogConfig();

        dialogConfig.autoFocus = true;
        dialogConfig.disableClose = true;
        dialogConfig.hasBackdrop = true;
        dialogConfig.ariaLabel = 'fffff';
        dialogConfig.width = "800px";

        const dialogRef = this.dialog.open(DialogCameraComponent,
            dialogConfig);

        dialogRef.afterClosed().subscribe(result => {
            if (result) {
                this.form.controls['avatar'].setValue(result._imageAsDataUrl);
                this.previewImage = result._imageAsDataUrl;
                this.form.controls['avatarChanged'].setValue(true);
            }
        });
    }

    public hasError = (controlName: string, errorName: string) => {
        return this.form.controls[controlName].hasError(errorName);
    }

    onNoClick(): void {
        this.dialogRef.close(false);
    }
    onYesClick(): void {
        setTimeout(() => {
            this.dialogRef.close(this.form.value);
        }, 100);
    }
}