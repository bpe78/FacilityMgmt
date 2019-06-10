import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FacilitiesComponent } from './facilities.component';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientModule } from '@angular/common/http';

describe('FacilitiesComponent', () => {
    let component: FacilitiesComponent;
    let fixture: ComponentFixture<FacilitiesComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            imports: [
                HttpClientModule,
                RouterTestingModule,
                MatCardModule,
                MatGridListModule,
                MatIconModule,
                MatMenuModule
            ],
            declarations: [FacilitiesComponent]
        })
            .compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(FacilitiesComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
