import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FacilityGroup } from '../models/facility-group.model';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class FacilityGroupService {

    constructor(private http: HttpClient) { }

    getGroups(): Observable<FacilityGroup[]> {
        return this.http
            .get<FacilityGroup[]>("/api/FacilityGroup");
    }

    addGroup(name: string)/*: Promise<bool> */{
        if((name == null) || (name == ''))
            throw new Error("FacilityGroupService:addGroup: invalid input");

        let newItem: FacilityGroup = { id: 0, name: name };
        let body: string = JSON.stringify(newItem);

        const httpOptions = {
            headers: new HttpHeaders({
              'Content-Type':  'application/json'
            })
        };
            
        this.http.post("/api/FacilityGroup", body, httpOptions)
        /*.subscribe(
            data => {
                console.log("POST Request is successful ", data);
            },
            error => {
                console.log("Error", error);
            }
        )*/
        .toPromise();
    }
}
