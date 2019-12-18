import { NgModule } from '@angular/core';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardHomeComponent } from './dashboard-home/dashboard-home.component';
import { AppSharedModule } from 'src/app/shared/app-shared.module';

@NgModule({
  declarations: [DashboardHomeComponent],
  imports: [
    AppSharedModule,
    DashboardRoutingModule
  ]
})
export class DashboardModule { }
