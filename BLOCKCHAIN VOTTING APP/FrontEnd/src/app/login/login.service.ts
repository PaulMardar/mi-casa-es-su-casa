import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginGuard } from '../guards/loginGuard';
@Injectable({
  providedIn: 'root'
})
export class LoginService {

  

  constructor(private http: HttpClient, private guard: LoginGuard) { }

  login(){

    console.log(localStorage.getItem('hash'));
  //  const headers = { 'Authorization': 'Bearer my-token', 'My-Custom-Header': 'foobar' };
    const body = {
      "hash" : localStorage.getItem('hash')
  };
    this.http.post<any>('http://127.0.0.1:5000/login', body, {}).subscribe(data => {
        console.log(data.token);
        if(typeof data.token != 'undefined' && data.token)
        {
            console.log("login guard true");
            this.guard.setLogin();
            console.log(this.guard.canActivate());
        }
        localStorage.setItem('token',data.token);
    });
  }
}
