import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ModulesComponent } from './modules/modules.component';

const routes: Routes = [{
  path: "", component: ModulesComponent, children: [
    { path: "", loadChildren: "./modules/dashboard/dashboard.module#DashboardModule" }
  ]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
