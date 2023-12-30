import { Component, OnDestroy } from '@angular/core';
import { takeWhile } from 'rxjs/operators';
import { forkJoin } from 'rxjs';

import { Contacts, RecentUsers, UserData } from '../../../@core/data/users';
import { PublisherService } from '../../../services/publisher.service';

@Component({
  selector: 'ngx-contacts',
  styleUrls: ['./contacts.component.scss'],
  templateUrl: './contacts.component.html',
})
export class ContactsComponent implements OnDestroy {

  private alive = true;

  contacts: any[];
  recent: any[];

  constructor(private userService: UserData,
    private publisherService: PublisherService
    ) {
    // forkJoin(
    //   this.userService.getContacts(),
    //   this.userService.getRecentUsers(),
    // )
    //   .pipe(takeWhile(() => this.alive))
    //   .subscribe(([contacts, recent]: [Contacts[], RecentUsers[]]) => {
    //     this.contacts = contacts;
    //     this.recent = recent;
    //   });
    ;
    this.publisherService
      .PostRequest("GetRetrieveClients", "")
      .subscribe((res: any) => {
        ;
        console.log(JSON.parse(res));

        var responce = JSON.parse(res);
        var array = JSON.parse(responce.ResponseMessage);

        var list = [];

        array.forEach((el) => {
          var obj = {
            data: {
              // EmployeeAddress: el["Employee Address"],
              ClientID: el["Client ID"],
              ClientName: el["Client Name"],
              ClientPhone: el["Client Phone"],
              ClientAddress: el["Client Address"],
              ClientEmail: el["Client Email"],
            },
          };
          ;
          list.push(obj);
        });

        this.contacts = list;
        // this.dataSource = this.dataSourceBuilder.create(this.data);

        console.log(this.contacts);
      });
  }

  ngOnDestroy() {
    // this.alive = false;

    

  }
}
