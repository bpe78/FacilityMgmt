import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateGroupDialogComponent } from './create-group-dialog.component';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

describe('CreateGroupDialogComponent', () => {
    let component: CreateGroupDialogComponent;
    let fixture: ComponentFixture<CreateGroupDialogComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            imports: [
                FormsModule,
                ReactiveFormsModule,
                MatDialogModule,
                MatFormFieldModule,
                MatInputModule,
                NoopAnimationsModule
            ],            
            declarations: [CreateGroupDialogComponent],
            providers: [
                { provide: MatDialogRef, useValue: {} },
            ]
        })
        .compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(CreateGroupDialogComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
