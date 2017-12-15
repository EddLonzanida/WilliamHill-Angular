var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { RaceStatResponse } from './responses/race-stat-response';
import { RaceStatService } from './race-stat.service';
var DashboardComponent = /** @class */ (function () {
    function DashboardComponent(raceStatService) {
        this.raceStatService = raceStatService;
        this.isBusy = true;
        this.hasErrors = false;
        this.raceStatResponse = new RaceStatResponse();
        this.colors = [];
        this.titleStyles = [];
        this.icons = [];
        this.safeIndex = 0;
    }
    DashboardComponent.prototype.ngAfterViewInit = function () {
        this.setColorArrays();
        this.search();
    };
    DashboardComponent.prototype.search = function () {
        var _this = this;
        this.isBusy = true;
        this.raceStatService.getStats()
            .then(function (r) {
            _this.raceStatResponse = r;
            _this.safeIndex = r.raceStats.length;
            if (_this.safeIndex > 5) {
                _this.safeIndex = 5;
            }
            ;
            _this.isBusy = false;
            _this.hasErrors = false;
            console.warn("getStats: " + r.raceStats);
            console.warn(r.raceStats);
        })
            .catch(function (e) {
            _this.isBusy = false;
            _this.hasErrors = true;
        });
    };
    DashboardComponent.prototype.isReady = function () {
        var isready = true;
        if (!this.raceStatResponse) {
            isready = false;
        }
        if (this.raceStatResponse.raceStats.length === 0) {
            return false;
        }
        return isready;
    };
    DashboardComponent.prototype.setColorArrays = function () {
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
    };
    DashboardComponent = __decorate([
        Component({
            selector: 'app-dashboard',
            templateUrl: './dashboard.component.html',
            styleUrls: ['./dashboard.component.css']
        }),
        __metadata("design:paramtypes", [RaceStatService])
    ], DashboardComponent);
    return DashboardComponent;
}());
export { DashboardComponent };
