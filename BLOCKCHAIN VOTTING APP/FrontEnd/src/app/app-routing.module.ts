import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DetailedProposalComponent } from './detailed-proposal/detailed-proposal.component';
import { ElectionComponent } from './election/election.component';
import { FinishedProposalsComponent } from './finished-proposals/finished-proposals.component';
import { LoginGuard } from './guards/loginGuard';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ProposalComponent } from './proposal/proposal.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  
 { path: 'proposals',canActivate: [LoginGuard],
   component: ProposalComponent },
  // { path: 'proposals', component: ProposalComponent },
  { path: 'login', component: LoginComponent },
  { path: 'proposals/:id', component: DetailedProposalComponent },
  
  { path: 'finishedProposal/:id', component: FinishedProposalsComponent },
  { path: 'elections', component: ElectionComponent },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
