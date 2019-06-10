import { TestBed } from '@angular/core/testing';
import { HttpClientModule } from '@angular/common/http';

import { FacilityService } from './facility.service';

describe('FacilityService', () => {
    beforeEach(() => TestBed.configureTestingModule({
        imports: [
            HttpClientModule,
        ],
    }));

    it('should be created', () => {
        const service: FacilityService = TestBed.get(FacilityService);
        expect(service).toBeTruthy();
    });
});
