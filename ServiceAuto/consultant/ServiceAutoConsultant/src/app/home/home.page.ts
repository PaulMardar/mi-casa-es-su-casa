import { Component, OnInit } from '@angular/core';
import { DataService } from '../services/data.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-home',
    templateUrl: 'home.page.html',
    styleUrls: ['home.page.scss'],
})
export class HomePage implements OnInit {

    public nr: number;
    constructor(private dataService: DataService, private router: Router) {
    }

    notifications() {
        // this.nr = this.dataService.getNumber();
    }

    async ngOnInit() {
        const value = await this.dataService.getStorage('userToken');
        if (!value) {
            this.router.navigate(['/register']);
        }else {
            this.router.navigate(['/home/requests']);
        }
    }

}
