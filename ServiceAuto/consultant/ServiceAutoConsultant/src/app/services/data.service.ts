import { Injectable } from '@angular/core';
import { Storage } from '@ionic/storage';
import {NavigationExtras, Router} from '@angular/router';
import { NetworkService  } from './network.service';

@Injectable({
    providedIn: 'root'
})
export class DataService {

    requestList = [];
    objectInProgress;
    historyList = [];

    constructor(private storage: Storage) { }

    updateRequestList(list: any []){
        this.requestList = list;
    }

    getItemByPhoneNumber(phoneNumber: string){
        let result = '';
        this.requestList.forEach((item) => {
            if (phoneNumber === item.phone) {
                result = item;
            }
        });
        return result;
    }

    setStorage(key: string, value: any) {
        return this.storage.set(key, value);
    }

    getStorage(key: string) {
        return this.storage.get(key);
    }

}
