import { TestBed, inject } from '@angular/core/testing';
import { RaceStatService } from './race-stat.service';
describe('RaceStatService', function () {
    beforeEach(function () {
        TestBed.configureTestingModule({
            providers: [RaceStatService]
        });
    });
    it('should be created', inject([RaceStatService], function (service) {
        expect(service).toBeTruthy();
    }));
});
