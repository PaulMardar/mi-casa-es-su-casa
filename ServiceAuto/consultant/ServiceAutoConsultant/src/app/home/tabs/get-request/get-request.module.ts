import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { GetRequestPageRoutingModule } from './get-request-routing.module';

import { GetRequestPage } from './get-request.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    GetRequestPageRoutingModule
  ],
  declarations: [GetRequestPage]
})
export class GetRequestPageModule {}
