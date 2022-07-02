import { Component, OnInit } from '@angular/core';
import { Proposal } from './proposal';
import { ProposalService } from './proposal.service';

@Component({
  selector: 'app-proposal',
  templateUrl: './proposal.component.html',
  styleUrls: ['./proposal.component.css']
})
export class ProposalComponent implements OnInit {


  proposals: Proposal[]= [];
  getProposals(): void
  {
    this.proposalService.getProposals()
        .subscribe(x => {this.proposals = x;
          console.log(x)
        }
          );
   
  }

  constructor(private proposalService: ProposalService) { }

  ngOnInit(): void {
    this.getProposals();
  }

}
