import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../services/data.service';
import { AlertController } from '@ionic/angular';
import { NavigationExtras, Router } from '@angular/router';
import { NetworkService } from '../../../services/network.service';

@Component({
    selector: 'app-requests',
    templateUrl: './requests.page.html',
    styleUrls: ['./requests.page.scss'],
})
export class RequestsPage implements OnInit {

    data: any = [];

    constructor(private dataService: DataService, private network: NetworkService) {
    }

    async ionViewWillEnter() {
        (await this.network.get('/get-cereri', true)).subscribe((response: any) => {
            this.data = response;
            this.dataService.updateRequestList(response);
            console.log(response);
        });
    }

    ngOnInit() {}
}
