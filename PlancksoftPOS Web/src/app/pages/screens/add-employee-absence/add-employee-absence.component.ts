import { Component, OnInit } from "@angular/core";
import { SmartTableData } from "../../../@core/data/smart-table";
import { LocalDataSource } from "ng2-smart-table";
import {
  NbSortDirection,
  NbSortRequest,
  NbToastrService,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
  NbWindowService,
} from "@nebular/theme";
import { AddEmployeeAbsenceModalComponent } from "../add-employee-absence-modal/add-employee-absence-modal.component";
import { AddEmployeeComponent } from "../add-employee/add-employee.component";
import { FormBuilder, FormGroup } from "@angular/forms";
import { PublisherService } from "../../../services/publisher.service";

@Component({
  selector: "ngx-add-employee-absence",
  templateUrl: "./add-employee-absence.component.html",
  styleUrls: ["./add-employee-absence.component.scss"],
})
export class AddEmployeeAbsenceComponent implements OnInit {
  Search: FormGroup;
  message: any;
  data: any;

  defaultColumns = [
    "AbsenceID",
    "AbsenceName",
    "AbsenceDate",
    "AbsenceHours",
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
    private windowService: NbWindowService,
    private fb: FormBuilder,
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>
  ) {
    const data = this.service.getData();
  }

  ngOnInit(): void {
    this.Search = this.fb.group({
      Date1: new Date(new Date().setHours(0, 0, 0, 0)),
      Date2: new Date(new Date().setHours(23, 59, 59, 999)),
    });

    var list = [];
    
    this.data = list;
    this.dataSource = this.dataSourceBuilder.create(this.data);
  }

  convertDateToJSONFormat(date) {
    var milliseconds = date.getTime();
    return "/Date(" + milliseconds + ")/";
  }

  search() {
    if (this.Search.valid) {
      console.log(this.Search.value);

      var obj = {
        Date1: this.convertDateToJSONFormat(new Date(new Date(this.Search.value.Date1).setHours(0, 0, 0, 0))),
        Date2: this.convertDateToJSONFormat(new Date(new Date(this.Search.value.Date2).setHours(23, 59, 59, 999))),
      };

      var list = [];

      this.publisherService
        .PostRequest("RetrieveAbsence", obj)
        .subscribe((res: any) => {
          console.log(JSON.parse(res));
          var response = JSON.parse(res);
          var array = JSON.parse(response.ResponseMessage);
           
          array.forEach((el) => {
            var obj = {
              data: {
                // EmployeeAddress: el["Employee Address"],
                AbsenceID: el["Absence ID"],
                EmployeeName: el["Employee Name"],
                AbsenceHours: el["Absence Hours"],
                AbsenceDate: el["Absence Date"],
                EmployeeID: el["Employee ID"],
              },
            };
            list.push(obj);
          });

          this.data = list;
          this.dataSource = this.dataSourceBuilder.create(this.data);
        });

      console.log();
    } else {
      this.toastrService.danger("Try Again", "Error");
    }

    console.log(this.Search.value);
  }

  AddAbsence() {
    var data = this.windowService.open(AddEmployeeAbsenceModalComponent, {
      title: `Insert Absence`,
    });

    data.componentInstance.modalClose.subscribe(() => {
      console.log("modal close");
      this.ngOnInit();
    });

    data.onClose.subscribe((res) => {
      this.ngOnInit();
    });
  }

  update(ID) {
     
    var SelectedData = this.data.filter((a) => a.data.AbsenceID == ID)[0];
    var obj = {
      AbsenceID: SelectedData.data.AbsenceID,
      Employeename: SelectedData.data.EmployeeName,
      AbsenceHours: SelectedData.data.AbsenceHours,
      AbsenceDate: SelectedData.data.AbsenceDate,
      EmployeeID: SelectedData.data.EmployeeID,
    };

    var data = this.windowService.open(AddEmployeeAbsenceModalComponent, {
      title: `Update Absence`,
      context: obj,
    });

    data.componentInstance.modalClose.subscribe(() => {
      console.log("modal close");
      this.ngOnInit();
    });

    data.onClose.subscribe((res) => {
      this.ngOnInit();
    });
  }

  Delete(ID) {
    var obj = {
      AbsenceID: ID,
    };

    this.publisherService
      .PostRequest("DeleteAbsence", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));
        this.ngOnInit();
      });
  }
}
