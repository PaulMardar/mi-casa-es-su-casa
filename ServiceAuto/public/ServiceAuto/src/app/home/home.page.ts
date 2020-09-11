import { Component, OnInit } from '@angular/core';
import { Sim } from '@ionic-native/sim/ngx';
import { DataService } from './data.service';

@Component({
    selector: 'app-home',
    templateUrl: 'home.page.html',
    styleUrls: ['home.page.scss'],
})
export class HomePage implements OnInit {

  phoneNo: string;
  numarTel : string;
  numarInmatr : string;

  constructor(private sim: Sim, private dataService: DataService) { }

  cereri = [];
  async ngOnInit() {
    if (!await this.sim.hasReadPermission()) {
      try {
        await this.sim.requestReadPermission();
      } catch (e) {
        return;
      }
    }

    send() {
        this.dataService.postSend({phone: this.phone, auto: this.inmatriculare}).subscribe(
            m => console.log(m),
            e => console.log(e)
        );
    }
  }

  send(){
    this.dataService.postCerere(this.numarTel,this.numarInmatr).subscribe((data) =>{
      console.log('Succes',data);
    }, (error) =>{
      console.log('error');
    }
    );
  }
}
