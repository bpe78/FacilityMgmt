import { Injectable } from '@angular/core';
import { Facility } from '../models/facility.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class FacilityService {

    constructor(private http: HttpClient) { }

    public facilityList(): Observable<Facility[]> {
        return this.http
            .get<Facility[]>("/api/Facility");
    }
}
