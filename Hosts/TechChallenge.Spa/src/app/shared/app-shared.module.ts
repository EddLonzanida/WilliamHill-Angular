import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StatisticsComponent } from './statistics/statistics.component';
import { BusyIndicatorComponent } from './busy-indicator/busy-indicator.component';
import { DebuggerPipe } from './pipes/debugger.pipe';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule, PanelModule } from 'primeng/primeng';
import { MenuModule } from 'primeng/menu';

@NgModule({
  declarations: [
    BusyIndicatorComponent,
    StatisticsComponent,
    DebuggerPipe
  ],
  imports: [
    PanelModule,
    MenuModule,
    CommonModule,
  ],
  exports: [
    CommonModule,
    BusyIndicatorComponent,
    StatisticsComponent,
    DebuggerPipe,
    ReactiveFormsModule,
    HttpClientModule,
    SharedModule,
    PanelModule,
    MenuModule
  ]
})
export class AppSharedModule { }
