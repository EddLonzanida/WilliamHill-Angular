var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { MenuModule, PanelModule, SharedModule } from 'primeng/primeng';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BusyIndicatorComponent } from './shared/busy-indicator/busy-indicator.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RaceStatService } from './dashboard/race-stat.service';
import { StatisticComponent } from './shared/statistic/statistic.component';
var appRoutes = [
    { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
    { path: 'dashboard', component: DashboardComponent },
];
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        NgModule({
            declarations: [
                AppComponent,
                BusyIndicatorComponent,
                DashboardComponent,
                StatisticComponent
            ],
            imports: [
                BrowserModule,
                FormsModule,
                RouterModule.forRoot(appRoutes),
                BrowserAnimationsModule,
                PanelModule,
                HttpModule,
                HttpClientModule,
                SharedModule,
                MenuModule,
            ],
            providers: [{ provide: 'BASE_URL', useFactory: getBaseUrl }, RaceStatService],
            bootstrap: [AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
export { AppModule };
export function getBaseUrl() {
    return 'http://localhost:44340/';
}
