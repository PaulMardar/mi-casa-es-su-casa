import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class DataService {
    serviceUrl = 'http://b2b.indecosoft.ro/api';

    constructor(private http: HttpClient) {
    }

    postSend(data) {
        console.log('works?');
        return this.http.post(`${this.serviceUrl}/cerere-noua`, data);
    }
}
