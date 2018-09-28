import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { BehaviorSubject } from 'rxjs';
import { FacilityGroup } from '../models/facility-group.model';
import { FacilityGroupService } from '../services/facility-group.service';
import { CreateGroupDialogComponent } from './create-group-dialog/create-group-dialog.component';

@Component({
    selector: 'app-groups',
    templateUrl: './groups.component.html',
    styleUrls: ['./groups.component.css']
})
export class GroupsComponent implements OnInit {
    groups: BehaviorSubject<FacilityGroup[]>;

    constructor(private facilityGroupService: FacilityGroupService, public dialog: MatDialog) {
        this.groups = new BehaviorSubject<FacilityGroup[]>([]);
        this.facilityGroupService.getGroups().subscribe(data => this.groups.next(data));
    }

    ngOnInit() {
    }

    openAddGroupDialog() {
        const dialogRef = this.dialog.open(CreateGroupDialogComponent, {
            width: '250px'
        });

        dialogRef.afterClosed().subscribe(result => {
            if(result != null)
                this.facilityGroupService.addGroup(result.name);
        });
    }
}
