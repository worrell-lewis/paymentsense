import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CountryTableComponent } from './country-table/country-table.component';

const routes: Routes = [
  { path: 'country-table', component: CountryTableComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
