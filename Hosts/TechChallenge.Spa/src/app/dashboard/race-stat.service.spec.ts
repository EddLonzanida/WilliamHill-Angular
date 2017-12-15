import { TestBed, inject } from '@angular/core/testing';

import { RaceStatService } from './race-stat.service';

describe('RaceStatService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RaceStatService]
    });
  });

  it('should be created', inject([RaceStatService], (service: RaceStatService) => {
    expect(service).toBeTruthy();
  }));
});
