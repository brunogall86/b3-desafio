import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InvestimentoCdbComponent } from './components/investimento-cdb/investimento-cdb.component';

const routes: Routes = [
  {
    path:"investimento-cdb",
    component: InvestimentoCdbComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
