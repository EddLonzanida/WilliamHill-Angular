import { Injectable } from '@angular/core';
import { SearchService } from './search.service';
import { RaceStatResponse } from 'src/app/modules/responses/race-stat-response';

@Injectable(({ providedIn: 'root' }) as any)
export class RaceStatService {

    constructor(private readonly searchService: SearchService) {
    }

    getStats() {

        const route = 'dashboard';

        return this.searchService.request<RaceStatResponse>('RaceStatService.getStats', route);
    }
}
