import { Component, OnInit, OnDestroy } from '@angular/core';
import { BroadcastService, MsalService } from '@azure/msal-angular';
import { Subscription } from 'rxjs';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy {
    title = 'FacilityMgmt';
    isLoggedIn: boolean;
    public userInfo: any = null;
    private subscription: Subscription;
    public isIframe: boolean;

    constructor(private broadcastService: BroadcastService, private authService: MsalService) {
        //  This is to avoid reload during acquireTokenSilent() because of hidden iframe
        this.isIframe = window !== window.parent && !window.opener;
        if (this.authService.getUser()) {
            this.isLoggedIn = true;
        }
        else {
            this.isLoggedIn = false;
        }
    }

    login() {
        this.authService.loginPopup(["user.read", "api://99edf7e2-52ba-41e7-8d6b-5fadb9b3f445/access_as_user"]);
    }

    logout() {
        this.authService.logout();
    }


    ngOnInit() {
        this.broadcastService.subscribe("msal:loginFailure", (payload) => {
            console.log("login failure");
            this.isLoggedIn = false;
        });

        this.broadcastService.subscribe("msal:loginSuccess", (payload) => {
            console.log("login success");
            this.isLoggedIn = true;
        });
    }

    ngOnDestroy() {
        this.broadcastService.getMSALSubject().next(1);
        if (this.subscription) {
            this.subscription.unsubscribe();
        }
    }
}
