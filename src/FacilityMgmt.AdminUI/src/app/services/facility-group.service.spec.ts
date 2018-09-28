import { TestBed } from '@angular/core/testing';

import { FacilityGroupService } from './facility-group.service';

describe('FacilityGroupService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: FacilityGroupService = TestBed.get(FacilityGroupService);
    expect(service).toBeTruthy();
  });
});
