import { Component, OnInit, AfterViewInit } from '@angular/core';
import { RaceStatResponse } from './responses/race-stat-response';
import { RaceStatService } from './race-stat.service';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements AfterViewInit {

    isBusy = true;
    hasErrors = false;
    raceStatResponse = new RaceStatResponse();
    colors: string[] = [];
    titleStyles: string[] = [];
    icons: string[] = [];
    safeIndex = 0;

    constructor(private raceStatService: RaceStatService) { }

    ngAfterViewInit(): void {

        this.setColorArrays();
        this.search();

    }

    search() {

        this.isBusy = true;
        this.raceStatService.getStats().subscribe(r => {
            this.raceStatResponse = r;
            this.safeIndex = r.raceStats.length;
            if (this.safeIndex > 5) { this.safeIndex = 5 };
            this.isBusy = false;
            this.hasErrors = false;
            console.warn(`getStats: ${r.raceStats}`);
            console.warn(r.raceStats);
        }, error => this.handleError());
    }

    isReady(): boolean {

        let bReady = true;

        if (!this.raceStatResponse) { bReady = false; }
        if (this.raceStatResponse.raceStats.length === 0) { return false; }

        return bReady;
    }

    private setColorArrays() {

        this.colors.push('#00ACAC');
        this.colors.push('#2F8EE5');
        this.colors.push('#6C76AF');
        this.colors.push('#EFA64C');
        this.colors.push('#A62E5C');
        // this.colors.push('#F15B2A');
        this.titleStyles.push('horse-panel-title-one');
        this.titleStyles.push('horse-panel-title-two');
        this.titleStyles.push('horse-panel-title-three');
        this.titleStyles.push('horse-panel-title-four');
        this.titleStyles.push('horse-panel-title-five');
        this.icons.push('fa-users');
        this.icons.push('fa-paw');
        this.icons.push('fa-area-chart');
        this.icons.push('fa-cogs');
        this.icons.push('fa-bolt');

    }

    private handleError() {

        this.isBusy = false;
        this.hasErrors = true;

    }
}
