import { Component, OnInit } from "@angular/core";
import { SmartTableData } from "../../../@core/data/smart-table";
import {
  NbSortDirection,
  NbSortRequest,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
  NbWindowService,
} from "@nebular/theme";
import { VendorAddModalComponent } from "../vendor-add-modal/vendor-add-modal.component";
import { PublisherService } from "../../../services/publisher.service";

@Component({
  selector: "ngx-vendors-defination",
  templateUrl: "./vendors-defination.component.html",
  styleUrls: ["./vendors-defination.component.scss"],
})
export class VendorsDefinationComponent implements OnInit {
  data: any;

  defaultColumns = [
    "Importer ID",
    "Importer Name",
    "Importer Phone Number",
    "Importer Address",
    "Importer Email",
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

  ngOnInit(): void {
    
    this.publisherService
      .PostRequest("GetRetrieveVendors", "")
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
              vendorID: el["Client ID"],
              vendorName: el["Client Name"],
              vendorPhone: el["Client Phone"],
              vendorAddress: el["Client Address"],
              vendorEmail: el["Client Email"],
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

  showTextField: any;

  toggleTextField() {
    this.showTextField = !this.showTextField;
  }

  button() {
    var data = this.windowService.open(VendorAddModalComponent, {
      title: `Add Importer`,
    });

    data.componentInstance.modalClose.subscribe((res) => {
      this.ngOnInit();
    });
  }

   updatevendor(id) {
        var selected = this.data.filter((a) => a.data.vendorID == id)[0];
    
        var obj = {
          ClientID: selected.data.vendorID,
          ClientName: selected.data.vendorName,
          ClientPhone: selected.data.vendorPhone,
          ClientAddress: selected.data.vendorAddress,
          ClientEmail: selected.data.vendorEmail,
        };
    
        var bcbc = this.windowService.open(VendorAddModalComponent, {
          title: `Update Importer`,
          context: obj,
        });

        bcbc.componentInstance.modalClose.subscribe(() => {
          console.log("modal close");
          this.ngOnInit();
        });

        bcbc.onClose.subscribe((res) => {
          this.publisherService
            .PostRequest("GetRetrieveVendors", "")
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
                    vendorID: el["Client ID"],
                    vendorName: el["Client Name"],
                    vendorPhone: el["Client Phone"],
                    vendorAddress: el["Client Address"],
                    vendorEmail: el["Client Email"],
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

  Delete(clientID) {
    var obj = {
      ClientID: clientID,
    };

    this.publisherService
    .PostRequest("DeleteClient", obj)
    .subscribe((res: any) => {
      this.ngOnInit();
    });
  }
}
