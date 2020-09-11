import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  serviceUrl = 'https://b2b.indecosoft.ro/api';
  constructor(private http: HttpClient) {}

  postCerere(numarTel: string, numarInmatr: string){
    return this.http.post(`${this.serviceUrl}/cerere-noua`, {phone:numarTel,auto:numarInmatr});
  }
}