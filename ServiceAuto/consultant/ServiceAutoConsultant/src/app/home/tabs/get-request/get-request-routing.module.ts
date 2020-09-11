import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { GetRequestPage } from './get-request.page';

const routes: Routes = [
  {
    path: '',
    component: GetRequestPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class GetRequestPageRoutingModule {}
