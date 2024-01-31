import { Component, OnInit } from "@angular/core";
import { LocalDataSource } from "ng2-smart-table";
import { SmartTableData } from "../../../@core/data/smart-table";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { PublisherService } from "../../../services/publisher.service";
import {
  NbSortDirection,
  NbSortRequest,
  NbToastrService,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
  NbWindowService,
} from "@nebular/theme";
import { UserModalComponent } from "../user-modal/user-modal.component";

@Component({
  selector: "ngx-user",
  templateUrl: "./user.component.html",
  styleUrls: ["./user.component.scss"],
})
export class UserComponent implements OnInit {
  firstFormGroup: FormGroup;
  message: any;
  data: any;
  updatedata: any;

  Authority: any;
  sell_edit: any;
  openclose_edit: any;
  personnel_edit: any;
  settings_edit: any;
  users_edit: any;
  expenses_add: any;
  inventory_edit: any;
  receipt_edit: any;
  price_edit: any;
  discount_edit: any;
  Client_card_edit: any;
  cashiername: any;

  defaultColumns = ["User ID", "User Name", "Password", "Permission", "Action"];
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
    private windowService: NbWindowService
  ) {}

  ngOnInit(): void {
    this.publisherService
      .PostRequest("RetrieveUsers", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        this.message = response.ResponseMessage.Item1;
        
        var list = [];
        this.message.forEach((el) => {
          var obj = {
            data: {
              Uid: el["Uid"],
              UserName: el["Name"],
              Password: el["pwd"],
              Authority: el["Authority"],
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

  deleteuser(ID) {
    var SelectedData = this.data.filter((a) => a.data.Uid == ID)[0];

    var obj = {
      UserToUpdate: {
        uid: SelectedData.data.Uid,
        pwd: SelectedData.data.Password,
        name: SelectedData.data.UserName,
        Client_card_edit: 1,
        discount_edit: 1,
        price_edit: 1,
        receipt_edit: 1,
        inventory_edit: 1,
        expenses_add: 1,
        users_edit: 1,
        settings_edit: 1,
        personnel_edit: 1,
        openclose_edit: 1,
        sell_edit: 1,
        Authority: 1,
      },
      cashierName: SelectedData.data.UserName,
    };

    this.publisherService
      .PostRequest("DeleteUser", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        this.ngOnInit();
      });
  }

  AddModal() {
    var dt = this.windowService.open(UserModalComponent, {
      title: `Insert User`,
    });

    dt.componentInstance.modalClose.subscribe(() => {
      console.log("modal close");
      this.ngOnInit();
    });

    dt.onClose.subscribe((res) => {
      this.ngOnInit();
    });
  }

  updateuser(id) {
    

    var SelectedData = this.data.filter((a) => a.data.Uid == id)[0];

    var obj = {
      Uid: SelectedData.data.Uid,
      UserName: SelectedData.data.UserName,
      Password: SelectedData.data.Password,
      Authority: SelectedData.data.Authority,
    };

    var dt = this.windowService.open(UserModalComponent, {
      title: `Update User`,
      context: obj,
    });

    dt.componentInstance.modalClose.subscribe(() => {
      console.log("modal close");
      this.ngOnInit();
    });

    dt.onClose.subscribe((res) => {
      this.ngOnInit();
    });

  }
}
