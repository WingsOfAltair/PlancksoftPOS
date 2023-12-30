import { Component, OnInit } from '@angular/core';
import { NbSortDirection, NbSortRequest, NbToastrService, NbTreeGridDataSource, NbTreeGridDataSourceBuilder, NbWindowService } from '@nebular/theme';
import { SmartTableData } from '../../../@core/data/smart-table';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PublisherService } from '../../../services/publisher.service';
import { PrinterModalComponent } from '../printer-modal/printer-modal.component';

@Component({
  selector: 'ngx-printer-setting',
  templateUrl: './printer-setting.component.html',
  styleUrls: ['./printer-setting.component.scss']
})
export class PrinterSettingComponent implements OnInit {

  data:any

  Return:FormGroup
  
  defaultColumns = [
    "ItemName",
    "ItemBarcode",
    "Action",
  ];
  
  allColumns = [...this.defaultColumns];

  dataSource: NbTreeGridDataSource<any>;

  sortColumn: string;
  sortDirection: NbSortDirection = NbSortDirection.NONE;

 
  constructor(
    private service: SmartTableData,
    private fb: FormBuilder,
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>,
    private windowService: NbWindowService,

  ) { }

  ngOnInit(): void {

    this.Return = this.fb.group({
      itemName:[],
      itemBarcode:[],
      ItemAmount:[],

    })  

    var obj = {
      machineName: "machine"
    };

    this.publisherService
    .PostRequest("RetrievePrinters", obj)
    .subscribe((res: any) => {
      ;
      console.log(JSON.parse(res));

      var responce = JSON.parse(res);
      var data = responce.ResponseMessage;

      console.log(this.data);

      var list = []
      data.forEach((el) => {
        var obj = {
          data: {
            
            ID: el["ID"],
            Name: el["Name"],
          
          }
        }
        ;
        list.push(obj);
      });

      this.data = list;
      this.dataSource = this.dataSourceBuilder.create(this.data);

      console.log(this.dataSource)

     });

  }

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

  AddModal(){
    
    var dt = this.windowService.open(PrinterModalComponent, {
      title: `Insert Printer Info`,
    });

    dt.onClose.subscribe((res) => {
      this.ngOnInit()
    })

  }

  update(id){


    var selected = this.data.filter(a => a.data.ID == id)[0]

    var obj = {
      Id: selected.data.ID,
      PrinterName: selected.data.Name
    }

    var dt = this.windowService.open(PrinterModalComponent, {
      title: `Update Printer Info`,
      context: obj
    });

    dt.onClose.subscribe((res) => { this.ngOnInit() })

  }

  delete(id){

    var selected = this.data.filter(a => a.data.ID == id)[0]

    var obj = {
      machineName: "machine",
      printerID: selected.data.ID
    }

    this.publisherService
    .PostRequest("DeletePrinter", obj)
    .subscribe((res: any) => {
      console.log(JSON.parse(res));
      this.ngOnInit()

    });


  }


}
