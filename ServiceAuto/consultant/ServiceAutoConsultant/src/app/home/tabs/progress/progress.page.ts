import { Component, OnInit, Input } from '@angular/core';
import { DataService } from '../../../services/data.service';
import { Request } from '../../../models/request.model';
import { ActivatedRoute, Router, NavigationExtras } from '@angular/router';
import { ActionSheetController } from '@ionic/angular';
import { navigateToTab } from 'src/app/helpers/NavigationHelper';

@Component({
    selector: 'app-progress',
    templateUrl: './progress.page.html',
    styleUrls: ['./progress.page.scss'],
})
export class ProgressPage {
    request: Request = null;

    viewModel: any;
    constructor(private dataService: DataService,
                private route: ActivatedRoute,
                private router: Router,
                public actionSheetController: ActionSheetController) {

    }

    ionViewWillEnter() {
       this.viewModel =  this.dataService.objectInProgress;
    }

    async openActionSheet() {
        const actionSheet = await this.actionSheetController.create({
            header: 'Alege un status',
            cssClass: 'my-custom-class',
            buttons: [{
                text: 'Renunta',
                role: 'cancel',
                cssClass: 'secondary',
                icon: 'close',
            }, {
                text: 'Rezolvat',
                icon: 'checkmark-done-circle-outline',
                handler: () => {
                    this.changeStatus(3);
                }
            }, {
                text: 'Nu poate fi contactat',
                icon: 'alert',
                handler: () => {
                    this.changeStatus(4);
                }
            }]
        });
        await actionSheet.present();
    }

    changeStatus(status: number) {
        const navigationExtra: NavigationExtras = {
            queryParams: {
                data: JSON.stringify({
                    openCall: false
                })
            }
        };
        this.viewModel.status = status;
        this.dataService.historyList.push(this.viewModel);
        this.viewModel = null;
        this.dataService.objectInProgress = null;
        this.router.navigate(['/home/get-request'], navigationExtra);
    }

    ionViewWillLeave(){}

}
