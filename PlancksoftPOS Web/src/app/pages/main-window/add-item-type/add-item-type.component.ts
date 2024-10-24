import { Component, OnInit } from "@angular/core";
import { LocalDataSource } from "ng2-smart-table";
import { SmartTableData } from "../../../@core/data/smart-table";
import {
  NbDialogService,
  NbSortDirection,
  NbSortRequest,
  NbToastrService,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
  NbWindowService,
} from "@nebular/theme";
import { FormBuilder, FormGroup } from "@angular/forms";
import { PublisherService } from "../../../services/publisher.service";
import { AddItemModalComponent } from "../add-item-modal/add-item-modal.component";
import { filter } from "rxjs-compat/operator/filter";

@Component({
  selector: "ngx-add-item-type",
  templateUrl: "./add-item-type.component.html",
  styleUrls: ["./add-item-type.component.scss"],
})
export class AddItemTypeComponent implements OnInit {
  itemGroup: FormGroup;
  message: any;
  dltId: any;
  data: any;
  Check: any;

  defaultColumns = ["Item ID", "Item Name", "Action"];
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
    private windowService: NbWindowService,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>
  ) {
    const data = this.service.getData();
  }

  delete(ID): void {
    this.dltId = ID;

    if (this.dltId > 0) {
      var obj = {
        ItemTypeID: this.dltId,
      };

      this.publisherService
        .PostRequest("DeleteItemType", obj)
        .subscribe((res: any) => {
          console.log(JSON.parse(res));
          this.ngOnInit();
        });
    } else {
    }
  }

  ngOnInit(): void {
    this.itemGroup = this.fb.group({
      itemtype: [""],
    });

    this.publisherService
      .PostRequest("RetrieveItemTypes", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        var message = response.ResponseMessage;

        var list = [];
        message.forEach((el) => {
          var obj = {
            data: {
              id: el["ID"],
              ItemName: el["Name"],
            },
          };
          list.push(obj);
        });

        this.data = list;
        this.dataSource = this.dataSourceBuilder.create(this.data);

        console.log(this.dataSource);
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

  SubmitData() {
    if (this.itemGroup.valid) {
      console.log(this.itemGroup.value);
      var obj = {
        ItemTypeName: this.itemGroup.value.itemtype,
      };

      this.publisherService
        .PostRequest("InsertItemType", obj)
        .subscribe((res: any) => {
          console.log(JSON.parse(res));
          this.ngOnInit();
        });
    } else {
      this.toastrService.danger("Try Again", "Error");
    }
  }

  Update(Id) {
    var selected = this.data.filter((a) => a.data.id == Id)[0];
    this.Check = selected.data.id;

    this.itemGroup.patchValue({
      itemID: selected.data.id,
      itemtype: selected.data.ItemName,
    });
  }

  Updatedata() {
    
    var obj = {
      ItemTypeName: this.itemGroup.value.itemtype,
      ItemTypeID: this.Check,
    };

    this.publisherService
      .PostRequest("UpdateItemTypes", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));
        this.ngOnInit();
        this.Check = null;
        this.itemGroup.reset();
      });
  }
}
