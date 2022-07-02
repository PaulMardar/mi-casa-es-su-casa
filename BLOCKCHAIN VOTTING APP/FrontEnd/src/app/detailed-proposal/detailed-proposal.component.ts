import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { Observable, switchMap } from 'rxjs';
import { Proposal } from '../proposal/proposal';
import { ProposalService } from '../proposal/proposal.service';

@Component({
  selector: 'app-detailed-proposal',
  templateUrl: './detailed-proposal.component.html',
  styleUrls: ['./detailed-proposal.component.css']
})
export class DetailedProposalComponent implements OnInit {

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
    this.redirectHome();
  }

  voteNo():void
  {  this.service.voteNo();
    console.log("vote no");
    this.redirectHome();
  }

  redirectHome(): void{
    this.router.navigate(['/proposals']);
  }

}


