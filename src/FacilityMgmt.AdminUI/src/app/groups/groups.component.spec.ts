import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialogModule } from '@angular/material/dialog';

import { GroupsComponent } from './groups.component';
import { HttpClientModule } from '@angular/common/http';

describe('GroupsComponent', () => {
    let component: GroupsComponent;
    let fixture: ComponentFixture<GroupsComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            imports: [
                HttpClientModule,
                MatDialogModule,
            ],
            declarations: [GroupsComponent]
        })
            .compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(GroupsComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
