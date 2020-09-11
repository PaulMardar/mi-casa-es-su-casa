import {Component, OnInit} from '@angular/core';
import {DataService} from '../services/data.service';
import {Router} from '@angular/router';
import {Storage} from '@ionic/storage';
import {NetworkService} from '../services/network.service';
import {ToastController} from '@ionic/angular';

@Component({
    selector: 'app-register',
    templateUrl: './register.page.html',
    styleUrls: ['./register.page.scss'],
})
export class RegisterPage implements OnInit {
    username: string;
    password: string;
    passwordHide: boolean;

    constructor(private networkService: NetworkService,
                private dataService: DataService,
                private router: Router,
                public toastController: ToastController) {
    }

    ngOnInit() {
        this.passwordHide = true;
    }

    async send() {
        ( await this.networkService.post('/register', {
            username: this.username,
            password: this.password
        })).subscribe(async (response: any) => {
                if (response) {
                    await this.dataService.setStorage('userToken', response.token);
                    this.router.navigate(['/home']);
                } else {
                    this.errorMsg('Login failed successfully!');
                }
            },
            error => console.error(error));
    }

    async errorMsg(msg) {
        const toast = await this.toastController.create({
            message: msg,
            duration: 2000
        });
        toast.present();
    }

    hide() {
        this.passwordHide = !this.passwordHide;
    }
}
