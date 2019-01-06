import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import {
  MenuModule, PanelModule,
  SharedModule
} from 'primeng/primeng';

import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BusyIndicatorComponent } from './shared/busy-indicator/busy-indicator.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RaceStatService } from './dashboard/race-stat.service';
import { SearchService } from './shared/services/search.service';
import { StatisticComponent } from './shared/statistic/statistic.component';

const appRoutes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent }
];

@NgModule({
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
    HttpClientModule,
    SharedModule,
    MenuModule
  ],
  providers: [{ provide: 'BASE_URL', useFactory: getBaseUrl }, SearchService, RaceStatService],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function getBaseUrl() {
    return 'http://localhost:44340/api/';
}

