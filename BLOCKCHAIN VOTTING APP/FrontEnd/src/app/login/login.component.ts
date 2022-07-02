import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import * as shajs from 'sha.js';
import { LoginService } from './login.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  secretSalt ="pie"
  cnp=''
  login(): void
  { 
    localStorage.setItem('hash',shajs('sha256').update(this.cnp.concat(this.secretSalt)).digest('hex'));
    this.cnp='';
    this.loginservice.login();
  }


  constructor(private loginservice: LoginService,    private route: ActivatedRoute,
    private router: Router) { }

  redirectHome(): void{
    this.router.navigate(['/home']);
  }


  ngOnInit(): void {
  }


}
