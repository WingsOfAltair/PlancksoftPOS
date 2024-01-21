import { Component, OnInit } from '@angular/core';
import { NbDialogService, NbWindowService } from '@nebular/theme';
import { PublisherService } from '../../../services/publisher.service';

@Component({
  selector: 'ngx-bill-recipt',
  templateUrl: './bill-recipt.component.html',
  styleUrls: ['./bill-recipt.component.scss']
})
export class BillReciptComponent implements OnInit {

  Userdata: any;
  userID: any;
  date: Date;
  message: any;
  logo: any;
  currentdate: Date;

  constructor(
    private dialogService: NbDialogService,
    private publisherService: PublisherService,
    private windowService: NbWindowService,
  ) {
    var user = sessionStorage.getItem("userData");
    this.Userdata = JSON.parse(user);
    this.userID = this.Userdata.uid;

    this.date = new Date();
   }

  ngOnInit(): void {

    this.publisherService
      .PostRequest("RetrieveSystemSettings", "")
      .subscribe((res: any) => {
        var response = JSON.parse(res);
        this.message = JSON.parse(response.ResponseMessage.Item1);

        this.logo = this.message[0].SystemName
        this.currentdate = new Date()

      });

  }

  

}
