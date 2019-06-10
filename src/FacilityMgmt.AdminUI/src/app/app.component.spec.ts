import { TestBed, async } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';

import { BroadcastService, MsalService } from '@azure/msal-angular';
import { AppComponent } from './app.component';
import { MSAL_CONFIG } from '@azure/msal-angular/dist/msal.service';

describe('AppComponent', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            imports: [
                RouterTestingModule,
                MatIconModule,
                MatToolbarModule
            ],
            declarations: [
                AppComponent
            ],
            providers: [
                BroadcastService,
                MsalService,
                { provide: MSAL_CONFIG, useValue: {} },
            ]
        }).compileComponents();
    }));
    it('should create the app', async(() => {
        const fixture = TestBed.createComponent(AppComponent);
        const app = fixture.debugElement.componentInstance;
        expect(app).toBeTruthy();
    }));
    it(`should have as title 'FacilityMgmt'`, async(() => {
        const fixture = TestBed.createComponent(AppComponent);
        const app = fixture.debugElement.componentInstance;
        expect(app.title).toEqual('FacilityMgmt');
    }));
});
