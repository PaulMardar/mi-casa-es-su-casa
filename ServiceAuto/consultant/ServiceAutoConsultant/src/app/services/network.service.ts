import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Request } from '../models/request.model';
import { map } from 'rxjs/operators';
import { DataService } from './data.service';

@Injectable({
    providedIn: 'root'
})
export class NetworkService {

    serviceUrl = 'https://b2b.indecosoft.ro/api';

    constructor(private http: HttpClient, private dataStorage: DataService) {
    }

    async get(url, secure = false) {
        return this.http
        // .get(this.serviceUrl + url, secure ? { headers: { Authorization: 'Bearer ' + this.dataStorage.getStorage('userToken') } } : {});
        .get(this.serviceUrl + url, secure ? { headers: { Authorization: await this.dataStorage.getStorage('userToken') } } : {});
    }

    async post(url, data, secure = false) {
        return this.http.post(this.serviceUrl + url, data, secure ? { headers: { Authorization: await this.dataStorage.getStorage('userToken') } } : {});
    }
}
