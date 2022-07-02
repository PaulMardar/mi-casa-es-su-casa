import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {


  redirectLogin(): void{
    this.router.navigate(['/login']);
  }

  
  redirectProposals(): void{
    if(localStorage.getItem('token') == null)
      {alert('Login First');}
    this.router.navigate(['/proposals']);
    

  }
  constructor(    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
  }
  title = 'Taking on chain governence off chain';
}
