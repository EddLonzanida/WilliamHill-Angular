import { Injectable } from '@angular/core';
import { RaceStatResponse } from './responses/race-stat-response';
import { SearchService } from "../shared/services/search.service";

@Injectable()
export class RaceStatService {

    constructor(private readonly searchService: SearchService) {
    }

    getStats() {
        const controller = "dashboard";

        return this.searchService.request<RaceStatResponse>(controller);
    }

}
