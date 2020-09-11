import {Component, OnInit} from '@angular/core';
import {NetworkService} from '../../../services/network.service';
import {DataService} from '../../../services/data.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-get-request',
    templateUrl: './get-request.page.html',
    styleUrls: ['./get-request.page.scss'],
})
export class GetRequestPage implements OnInit {

    requestNumber = 0;

    constructor( private networkService: NetworkService, private dataService: DataService, private router: Router) {
    }

    async ionViewWillEnter() {
        (await this.networkService.get('/home', true)).subscribe( (m: any) => this.requestNumber = m.cereriInAsteptare);
    }

    ngOnInit() {
    }

    async getRequest() {
        (await this.networkService.get('/preia-cerere', true)).subscribe((m: any) =>
        {
            this.dataService.objectInProgress = this.dataService.getItemByPhoneNumber(m.phone);
            console.log(this.dataService.objectInProgress);
            this.router.navigate(['/home/progress']);
        });

    }
}
