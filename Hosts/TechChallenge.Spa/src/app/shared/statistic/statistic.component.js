var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input } from '@angular/core';
var StatisticComponent = /** @class */ (function () {
    function StatisticComponent() {
        this.horseStats = [];
    }
    StatisticComponent.prototype.ngOnInit = function () {
    };
    __decorate([
        Input(),
        __metadata("design:type", String)
    ], StatisticComponent.prototype, "icon", void 0);
    __decorate([
        Input(),
        __metadata("design:type", String)
    ], StatisticComponent.prototype, "label", void 0);
    __decorate([
        Input(),
        __metadata("design:type", String)
    ], StatisticComponent.prototype, "value", void 0);
    __decorate([
        Input(),
        __metadata("design:type", String)
    ], StatisticComponent.prototype, "colour", void 0);
    __decorate([
        Input(),
        __metadata("design:type", String)
    ], StatisticComponent.prototype, "titleStyle", void 0);
    __decorate([
        Input(),
        __metadata("design:type", Array)
    ], StatisticComponent.prototype, "horseStats", void 0);
    StatisticComponent = __decorate([
        Component({
            selector: 'app-statistic',
            templateUrl: './statistic.component.html',
            styleUrls: ['./statistic.component.css']
        }),
        __metadata("design:paramtypes", [])
    ], StatisticComponent);
    return StatisticComponent;
}());
export { StatisticComponent };
