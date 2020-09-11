import {Component, OnInit, Input} from '@angular/core';
import {DataService} from '../../../services/data.service';
import {Request} from '../../../models/request.model';
import {ActivatedRoute} from '@angular/router';

@Component({
    selector: 'app-done',
    templateUrl: './done.page.html',
    styleUrls: ['./done.page.scss'],
})
export class DonePage implements OnInit {
    request: Request = null;

  constructor(private dataService: DataService, private route: ActivatedRoute) {
    this.route.queryParams.subscribe(params => {
      // console.log(params.data);
      // if (params && params.data) {
      //     const data = JSON.parse(params.data);
      //     this.request = new Request(data.phone, data.auto, data.stamp, data.status);
      // }
  });
   }

  ngOnInit() {
    // this.done = this.dataService.getDone();
  }


}
