import { Component, OnInit } from "@angular/core";
import {
  NbSortDirection,
  NbSortRequest,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
  NbWindowService,
} from "@nebular/theme";
import { SmartTableData } from "../../../@core/data/smart-table";
import { ClientAddModalComponent } from "../client-add-modal/client-add-modal.component";
import { PublisherService } from "../../../services/publisher.service";

@Component({
  selector: "ngx-client-defination",
  templateUrl: "./client-defination.component.html",
  styleUrls: ["./client-defination.component.scss"],
})
export class ClientDefinationComponent implements OnInit {
  data: any;

  defaultColumns = [
    "Client ID",
    "Client Name",
    "Phone Number",
    "Client Address",
    "Client Email",
    "Action",
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
    private windowService: NbWindowService,
    private publisherService: PublisherService
  ) {}

  showTextField: any;

  toggleTextField() {
    this.showTextField = !this.showTextField;
  }
  ngOnInit(): void {
    ;
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
              ClientPhone: el["Client Phone"],
              ClientAddress: el["Client Address"],
              ClientEmail: el["Client Email"],
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

  button() {
    var data = this.windowService.open(ClientAddModalComponent, {
      title: `Add Client`,
    });

    data.onClose.subscribe((res) => {
      this.ngOnInit()
    })

  }

  updateEmployee(id) {
      var selected = this.data.filter((a) => a.ClientID == id)[0];
  
      var obj = {
        ClientID: selected.ClientID,
        ClientName: selected.ClientName,
        ClientPhone: selected.ClientPhone,
        ClientAddress: selected.ClientAddress,
        ClientEmail: selected.ClientEmail,
      };
  
      var bcbc = this.windowService.open(ClientAddModalComponent, {
        title: `Update Item`,
        context: obj,
      });
      bcbc.onClose.subscribe((res) => {
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
                  ClientPhone: el["Client Phone"],
                  ClientAddress: el["Client Address"],
                  ClientEmail: el["Client Email"],
                },
              };
              ;
              list.push(obj);
            });

            this.data = list;
            this.dataSource = this.dataSourceBuilder.create(this.data);

            console.log(this.dataSource);
          });
      });
    }

  Delete(id) {
    var obj = {
      ClientID: id,
    };

    this.publisherService
      .PostRequest("DeleteClient", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));
        this.ngOnInit();
      });
  }
}
