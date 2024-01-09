import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { NbSortDirection, NbSortRequest, NbTreeGridDataSource, NbTreeGridDataSourceBuilder } from '@nebular/theme';
import { PublisherService } from '../../../services/publisher.service';

@Component({
  selector: 'ngx-pick-client',
  templateUrl: './pick-client.component.html',
  styleUrls: ['./pick-client.component.scss']
})
export class PickClientComponent implements OnInit {

  filterdata: any
  data:any

  defaultColumns = [
    "ClientID",
    "ClientName",
  ];


  allColumns = [...this.defaultColumns];


  dataSource: NbTreeGridDataSource<any>;


  sortColumn: string;
  sortDirection: NbSortDirection = NbSortDirection.NONE;


  updateSort(sortRequest: NbSortRequest): void {
    this.sortColumn = sortRequest.column;
    this.sortDirection = sortRequest.direction;
  }


  getSortDirection(column: string): NbSortDirection {
    if (this.sortColumn === column) {
      return this.sortDirection;
    }
    return NbSortDirection.NONE;
  }
  getShowOn(index: number) {
    const minWithForMultipleColumns = 400;
    const nextColumnStep = 100;
    return minWithForMultipleColumns + nextColumnStep * index;
  }


  constructor(
    private fb: FormBuilder,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>,
    private publisherService: PublisherService,
  ) {}


  ngOnInit(): void {

    this.publisherService
      .PostRequest("GetRetrieveClients", "")
      .subscribe((res: any) => {
        ;
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        var array = JSON.parse(response.ResponseMessage);

        var list = [];

        array.forEach((el) => {
          var obj = {
            data: {
              // EmployeeAddress: el["Employee Address"],
              ClientID: el["Client ID"],
              ClientName: el["Client Name"],
            },
          };
          ;
          list.push(obj);
        });

        this.data = list;
        this.dataSource = this.dataSourceBuilder.create(this.data);

        console.log(this.dataSource);
      });

  }



}
