import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StatisticsComponent } from './statistics/statistics.component';
import { BusyIndicatorComponent } from './busy-indicator/busy-indicator.component';
import { DebuggerPipe } from './pipes/debugger.pipe';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule, PanelModule } from 'primeng/primeng';
import { MenuModule } from 'primeng/menu';
import { EmlCheckboxComponent } from './eml-checkbox/eml-checkbox.component';

@NgModule({
  declarations: [
    BusyIndicatorComponent,
    StatisticsComponent,
    DebuggerPipe,
    EmlCheckboxComponent
  ],
  imports: [
    PanelModule,
    CommonModule
  ],
  exports: [
    CommonModule,
    BusyIndicatorComponent,
    EmlCheckboxComponent,
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
