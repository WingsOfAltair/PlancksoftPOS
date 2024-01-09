import { Component, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { SmartTableData } from '../../../@core/data/smart-table';
import { FormBuilder } from '@angular/forms';
import { NbSortDirection, NbSortRequest, NbTreeGridDataSource, NbTreeGridDataSourceBuilder } from '@nebular/theme';
import { PublisherService } from '../../../services/publisher.service';

@Component({
  selector: 'ngx-import-export-capital',
  templateUrl: './import-export-capital.component.html',
  styleUrls: ['./import-export-capital.component.scss']
})
export class ImportExportCapitalComponent implements OnInit {

  import: any
  export: any
  capital:any


  defaultColumns = ["TotalCost", "Date"];


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


  defaultColumns2 = ["Date", "TotalCost"];


  allColumns2 = [...this.defaultColumns2];


  dataSource2: NbTreeGridDataSource<any>;


  sortColumn2: string;
  sortDirection2: NbSortDirection = NbSortDirection.NONE;


  updateSort2(sortRequest: NbSortRequest): void {
    this.sortColumn2 = sortRequest.column;
    this.sortDirection2 = sortRequest.direction;
  }
  getSortDirection2(column: string): NbSortDirection {
    if (this.sortDirection2 === column) {
      return this.sortDirection2;
    }
    return NbSortDirection.NONE;
  }
  getShowOn2(index: number) {
    const minWithForMultipleColumns = 400;
    const nextColumnStep = 100;
    return minWithForMultipleColumns + nextColumnStep * index;
  }


  defaultColumns3 = ["NetProfit", "Date"];


  allColumns3 = [...this.defaultColumns3];


  dataSource3: NbTreeGridDataSource<any>;


  sortColumn3: string;
  sortDirection3: NbSortDirection = NbSortDirection.NONE;


  updateSort3(sortRequest: NbSortRequest): void {
    this.sortColumn3 = sortRequest.column;
    this.sortDirection3 = sortRequest.direction;
  }
  getSortDirection3(column: string): NbSortDirection {
    if (this.sortDirection3 === column) {
      return this.sortDirection3;
    }
    return NbSortDirection.NONE;
  }
  getShowOn3(index: number) {
    const minWithForMultipleColumns = 400;
    const nextColumnStep = 100;
    return minWithForMultipleColumns + nextColumnStep * index;
  }


  constructor(
    private service: SmartTableData,
    private fb: FormBuilder,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>,
    private publisherService: PublisherService,

  ) {}

  ngOnInit(): void {
    
    this.publisherService
    .PostRequest("RetrieveImports", "")
    .subscribe((res: any) => {
      ;
      console.log(JSON.parse(res));

      var response = JSON.parse(res);
      var array = JSON.parse(response.ResponseMessage.Item2);

      var list = [];

      array.forEach((el) => {
        var obj = {
          data: {
            Date: el["Date"],
            TotalCost: el["Total Cost"],
          },
        };
        ;
        list.push(obj);
      });

      this.import = list;
      this.dataSource = this.dataSourceBuilder.create(this.import);

      console.log(this.dataSource);
    });


    this.publisherService
    .PostRequest("RetrieveExports", "")
    .subscribe((res: any) => {
      ;
      console.log(JSON.parse(res));

      var response = JSON.parse(res);
      var array = JSON.parse(response.ResponseMessage.Item2);

      var list = [];

      array.forEach((el) => {
        var obj = {
          data: {
            Date: el["Date"],
            TotalCost: el["Total Cost"],
          },
        };
        ;
        list.push(obj);
      });

      this.export = list;
      this.dataSource2 = this.dataSourceBuilder.create(this.export);

      console.log(this.dataSource);
    });


    this.publisherService
    .PostRequest("RetrieveCapitalRevenue", "")
    .subscribe((res: any) => {
      ;
      console.log(JSON.parse(res));

      var response = JSON.parse(res);
      var array = JSON.parse(response.ResponseMessage.Item2);

      var list = [];

      array.forEach((el) => {
        var obj = {
          data: {
           
            Date: el["Date"],
            TotalRevenue: el["Total Revenue"],
          },
        };
        ;
        list.push(obj);
      });

      this.capital = list;
      this.dataSource3 = this.dataSourceBuilder.create(this.capital);

      console.log(this.dataSource);
    });


  }

}


