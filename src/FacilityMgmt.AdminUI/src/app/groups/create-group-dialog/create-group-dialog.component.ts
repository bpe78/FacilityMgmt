import { Component, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
    selector: 'app-create-group-dialog',
    templateUrl: './create-group-dialog.component.html',
    styleUrls: ['./create-group-dialog.component.css']
})
export class CreateGroupDialogComponent {
    form: FormGroup;
    name: string;

    constructor(private fb: FormBuilder,
        private dialogRef: MatDialogRef<CreateGroupDialogComponent>) {

        this.form = fb.group({
            name: [name, Validators.required]
        });
    }

    save() {
        this.dialogRef.close(this.form.value);
    }

    cancel() {
        this.dialogRef.close();
    }
}
