import { Component, OnInit } from '@angular/core';
import { NbSortDirection, NbSortRequest, NbTreeGridDataSource, NbTreeGridDataSourceBuilder, NbWindowService } from '@nebular/theme';
import { SmartTableData } from '../../../@core/data/smart-table';
import { PublisherService } from '../../../services/publisher.service';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'ngx-tax-report',
  templateUrl: './tax-report.component.html',
  styleUrls: ['./tax-report.component.scss']
})
export class TaxReportComponent implements OnInit {

  
  TaxZReport: FormGroup;
  data: any;

  defaultColumns = [
    "Client ID",
    "Client Name",
    "Phone Number",
    "Client Address",
    "Taxtotal",
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
    private service: SmartTableData,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>,
    private fb: FormBuilder,
    private windowService: NbWindowService,
    private publisherService: PublisherService
  ) {}

  showTextField: any;

  toggleTextField() {
    this.showTextField = !this.showTextField;
  }

  convertDateToJSONFormat(date) {
    var milliseconds = date.getTime();
    return "/Date(" + milliseconds + ")/";
  }

  ngOnInit(): void {
    this.TaxZReport = this.fb.group({
      StartDate: [],
      EndDate: [],
    });

    this.SearchData();
  }

  SearchData() {
    var obj = {
      StartDate: this.TaxZReport.value.StartDate,
      EndDate: this.TaxZReport.value.EndDate,
    };

  this.publisherService
    .PostRequest("RetrieveTaxZReport", obj)
    .subscribe((res: any) => {
      ;
      console.log(JSON.parse(res));

      var response = JSON.parse(res);
      var array = JSON.parse(response.ResponseMessage);

      var list = [];

      var  taxTotal = 0;
      var billTotal = 0;

      array.forEach((el) => {
        var obj = {
          data: {
            BillID: el["Bill Number"],
            Billtotal: el["Total Amount"],
            taxAmount: el["Tax"],
            date: el["Date"],
            TaxTotal: el["TaxTotal"],
          },
        };

        billTotal += parseFloat(el["Total Amount"]);
        taxTotal += parseFloat(el["Tax"]);
        
        list.push(obj);
      });
      var obj = {
        data: {
          BillID: "Total",
          Billtotal: billTotal,
          TaxTotal: taxTotal,
        },
      };
      list.push(obj);

      this.data = list;
      this.dataSource = this.dataSourceBuilder.create(this.data);

      console.log(this.dataSource);
    });
  }
}
