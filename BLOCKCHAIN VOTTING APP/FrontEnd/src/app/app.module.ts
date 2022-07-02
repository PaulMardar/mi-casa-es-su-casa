import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProposalComponent } from './proposal/proposal.component';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';

import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './login/login.component';
import { DetailedProposalComponent } from './detailed-proposal/detailed-proposal.component';
import { ElectionComponent } from './election/election.component';
import { DetailedElectionComponent } from './detailed-election/detailed-election.component';
import { LoginGuard } from './guards/loginGuard';
import { FinishedProposalsComponent } from './finished-proposals/finished-proposals.component';
@NgModule({
  declarations: [
    AppComponent,
    ProposalComponent,
    HomeComponent,
    LoginComponent,
    DetailedProposalComponent,
    ElectionComponent,
    DetailedElectionComponent,
    FinishedProposalsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [LoginGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
