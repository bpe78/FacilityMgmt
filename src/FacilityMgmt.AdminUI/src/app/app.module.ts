import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MsalModule, MsalInterceptor } from '@azure/msal-angular';
import { LogLevel } from "msal";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatOptionModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatSelectModule } from '@angular/material/select';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatDialogModule } from '@angular/material/dialog';
import { GroupsComponent } from './groups/groups.component';
import { CreateGroupDialogComponent } from './groups/create-group-dialog/create-group-dialog.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FacilitiesComponent } from './facilities/facilities.component';
import { FacilityService } from './services/facility.service';
import { environment } from '../environments/environment';

export function loggerCallback(logLevel, message, piiEnabled) {
    console.log("client logging" + message);
}

@NgModule({
    declarations: [
        AppComponent,
        GroupsComponent,
        CreateGroupDialogComponent,
        FacilitiesComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        MsalModule.forRoot({
            clientID: environment.clientId,
            authority: environment.authority,
            validateAuthority: true,
            redirectUri: "http://localhost:4200/",
            cacheLocation : "localStorage",
            postLogoutRedirectUri: "https://localhost:4200/",
            navigateToLoginRequestUrl: true,
            popUp: true,
            consentScopes: [ `api://${environment.clientId}/access_as_user`],
            unprotectedResources: ["https://www.microsoft.com/en-us/"],
            logger: loggerCallback,
            correlationId: '1234',
            level: LogLevel.Info,
            piiLoggingEnabled: true
        }), 
        BrowserAnimationsModule,
        HttpClientModule,
        LayoutModule,
        FormsModule,
        ReactiveFormsModule,
        MatCardModule,
        MatDialogModule,
        MatFormFieldModule,
        MatGridListModule,
        MatInputModule,
        MatMenuModule,
        MatToolbarModule,
        MatButtonModule,
        MatButtonToggleModule,
        MatCheckboxModule,
        MatIconModule,
        MatListModule,
        MatOptionModule,
        MatSelectModule
    ],
    providers: [
        FacilityService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: MsalInterceptor,
            multi: true
        }
    ],
    bootstrap: [AppComponent],
    entryComponents: [CreateGroupDialogComponent]
})
export class AppModule { }
