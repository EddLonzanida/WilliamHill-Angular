var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/toPromise';
var RaceStatService = /** @class */ (function () {
    function RaceStatService(http, httpClient, baseUrl) {
        this.http = http;
        this.httpClient = httpClient;
        this.baseUrl = baseUrl;
    }
    RaceStatService.prototype.getStats = function () {
        return this.http.get(this.baseUrl + "dashboard")
            .toPromise()
            .then(function (res) {
            return res.json();
        })
            .then(function (data) { return data; });
    };
    RaceStatService = __decorate([
        Injectable(),
        __param(2, Inject('BASE_URL')),
        __metadata("design:paramtypes", [Http, HttpClient, String])
    ], RaceStatService);
    return RaceStatService;
}());
export { RaceStatService };
