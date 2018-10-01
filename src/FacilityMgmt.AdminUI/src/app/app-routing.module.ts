import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GroupsComponent } from './groups/groups.component';
import { FacilitiesComponent } from './facilities/facilities.component';

const routes: Routes = [
    {
        path: 'groups',
        component: GroupsComponent,
        //canActivate : [MsalGuard]
    },
    {
        path: 'facilities',
        component: FacilitiesComponent,
        //canActivate : [MsalGuard]
    },
    {
        path: 'facilities/:id',
        component: FacilitiesComponent,
        //canActivate : [MsalGuard]
    },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
