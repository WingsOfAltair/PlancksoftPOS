import { Component, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { SmartTableData } from '../../../@core/data/smart-table';
import { NbDialogService, NbSortDirection, NbSortRequest, NbToastrService, NbTreeGridDataSource, NbTreeGridDataSourceBuilder } from '@nebular/theme';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PublisherService } from '../../../services/publisher.service';

@Component({
  selector: 'ngx-add-wearhouse',
  templateUrl: './add-wearhouse.component.html',
  styleUrls: ['./add-wearhouse.component.scss']
})
export class AddWearhouseComponent implements OnInit {


  message: any
  dltId:any
  data:any
  Check:any

  itemGroup:FormGroup

  defaultColumns = [
    " ID",
    " Name",
    "Action",
  ];
  allColumns = [...this.defaultColumns];

  dataSource: NbTreeGridDataSource<any>;

  sortColumn: string;
  sortDirection: NbSortDirection = NbSortDirection.NONE;

  constructor(
    private service: SmartTableData,
    private dialogService: NbDialogService,
    private fb: FormBuilder,
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>

  ) {
    const data = this.service.getData();
  }

  onDeleteConfirm(event): void {
    

    this.dltId = event

    if (this.dltId > 0) {
      var obj = {
        "WarehouseID": this.dltId
      }
      
      this.publisherService.PostRequest('DeleteWarehouse', obj).subscribe((res: any) => {
        console.log(JSON.parse(res));
        this.ngOnInit()
      });
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
    
  }  


  ngOnInit(): void {

    this.itemGroup = this.fb.group({
      Wearhouse: ['']
    })

    
    this.publisherService.PostRequest('RetrieveWarehouses', "").subscribe((res: any) => {
      
      console.log(JSON.parse(res));

      var responce = JSON.parse(res);
      var message = responce.ResponseMessage;

      var list = []
      message.forEach((el) => {
        var obj = {
          data: {
            id: el["ID"],
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

  SubmitData() {
    
    if (this.itemGroup.valid) {
      console.log(this.itemGroup.value);
      var obj = {
        "WarehouseName": this.itemGroup.value.Wearhouse
      }
      
      this.publisherService.PostRequest('InsertWarehouse', obj).subscribe((res: any) => {
        console.log(JSON.parse(res));
        this.ngOnInit()
      });
    }
    else {
      this.toastrService.danger( 'Try Again',"Error",);
    }
  }

  Update(Id){
    
    var selected = this.data.filter(a => a.data.id == Id)[0]
    this.Check = selected.data.id

    this.itemGroup.patchValue({
      
      Wearhouse: selected.data.Name
    })
  }

  Updatedata(){

    var obj = {
      "WarehouseName": this.itemGroup.value.Wearhouse,
      "WarehouseID": this.Check
    }

    
    this.publisherService.PostRequest('UpdateWarehouses', obj).subscribe((res: any) => {
      console.log(JSON.parse(res));
      this.ngOnInit()
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

}
