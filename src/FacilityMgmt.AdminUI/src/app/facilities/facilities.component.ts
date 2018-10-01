import { Component, OnInit } from '@angular/core';
import { FacilityService } from '../services/facility.service';
import { Router } from '@angular/router';
import { Facility } from '../models/facility.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-facilities',
  templateUrl: './facilities.component.html',
  styleUrls: ['./facilities.component.css']
})
export class FacilitiesComponent implements OnInit {
    facilities: Observable<Facility[]>;
    
    constructor(private _facilityService: FacilityService, private router: Router) {
    }

    ngOnInit() {
        this.facilities = this._facilityService.facilityList();
    }

    public disable(id: string) {
        alert("disabled" + id);
    }

    public edit(id: string) {
        this.router.navigate(['facilities', id]);
    }  
}
