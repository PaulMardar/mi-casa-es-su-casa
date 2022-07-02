import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Election } from './election';

@Component({
  selector: 'app-election',
  templateUrl: './election.component.html',
  styleUrls: ['./election.component.css']
})
export class ElectionComponent implements OnInit {

  election$!: Observable<Election>;

  constructor() { }

  ngOnInit(): void {
  }

}
