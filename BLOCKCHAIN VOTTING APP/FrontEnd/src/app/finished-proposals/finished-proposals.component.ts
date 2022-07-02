import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { Observable, switchMap } from 'rxjs';
import { Proposal } from '../proposal/proposal';
import { ProposalService } from '../proposal/proposal.service';
@Component({
  selector: 'app-finished-proposals',
  templateUrl: './finished-proposals.component.html',
  styleUrls: ['./finished-proposals.component.css']
})

export class FinishedProposalsComponent implements OnInit {

  proposal$!: Observable<Proposal>;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: ProposalService
  ) {}

  ngOnInit(): void {
    this.proposal$ = this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
        this.service.getProposadId(params.get('id')!))
    );
  }
  
  voteYes():void
  {
    this.service.voteYes();
    console.log("vote yes");
  }

  voteNo():void
  { 
    console.log("vote no");
  }

  redirectHome(): void{
    this.router.navigate(['/proposals']);
  }

}


