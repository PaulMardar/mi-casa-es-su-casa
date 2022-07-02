
import {CanActivate} from "@angular/router";

export class LoginGuard implements CanActivate {

  isLoggedIN : boolean;


  setLogin()
{
  this.isLoggedIN = true;
}

constructor()
{
  this.isLoggedIN = false;
}

    canActivate() {
      console.log(localStorage.getItem('token'));
      return localStorage.getItem('token') != null;
    }
  }