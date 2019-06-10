import { TestBed } from '@angular/core/testing';

import { FacilityGroupService } from './facility-group.service';
import { HttpClientModule } from '@angular/common/http';

describe('FacilityGroupService', () => {
    beforeEach(() => TestBed.configureTestingModule({
        imports: [
            HttpClientModule,
        ],
    }));

    it('should be created', () => {
        const service: FacilityGroupService = TestBed.get(FacilityGroupService);
        expect(service).toBeTruthy();
    });
});
