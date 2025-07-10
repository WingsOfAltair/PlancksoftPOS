import { Component, OnInit } from "@angular/core";
import { LocalDataSource } from "ng2-smart-table";
import { SmartTableData } from "../../../@core/data/smart-table";
import { AddEmployeeComponent } from "../add-employee/add-employee.component";
import { AddEmployeeAbsenceModalComponent } from "../add-employee-absence-modal/add-employee-absence-modal.component";
import {
  NbSortDirection,
  NbSortRequest,
  NbToastrService,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
  NbWindowService,
} from "@nebular/theme";
import { AddEmployeeSaleryDeductModalComponent } from "../add-employee-salery-deduct-modal/add-employee-salery-deduct-modal.component";
import { PublisherService } from "../../../services/publisher.service";
import { FormBuilder, FormGroup } from "@angular/forms";

interface FSEntry {
  name: string;
  size: string;
  kind: string;
  items?: number;
}

@Component({
  selector: "ngx-employee",
  templateUrl: "./employee.component.html",
  styleUrls: ["./employee.component.scss"],
})
export class EmployeeComponent implements OnInit {
  list: any = [];
  data: any = [];

  Search: FormGroup;

  defaultColumns = [
    "EmployeeID",
    "EmployeeName",
    "Salary",
    "DeductedSalary",
    "PhoneNumber",
    "Address",
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
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>,
    private fb: FormBuilder
  ) {
    // const data = this.service.getData();
    // this.dataSource = this.dataSourceBuilder.create(this.tabledata);
  }

  ngOnInit(): void {
    this.Search = this.fb.group({
      Date1: new Date(new Date().setHours(0, 0, 0, 0)),
      Date2: new Date(new Date().setHours(23, 59, 59, 999)),
    });

    this.publisherService
    .PostRequest("RetrieveEmployeesData", "")
    .subscribe((res: any) => {
      ;
      console.log(JSON.parse(res));

      var response = JSON.parse(res);
      var array = JSON.parse(response.ResponseMessage);

      var list = [];

      array.forEach((el) => {
        var obj = {
          data: {
            EmployeeID: el["Employee ID"],
            EmployeeName: el["Employee Name"],
            Salary: el["Employee Salary"],
            PhoneNumber: el["Employee Phone"],
            Address: el["Employee Address"],
            DeductedSalary: el["Deducted Salary"],
            deductID: el["Deduct ID"]
          },
        };
        list.push(obj);
      });

      this.data = list;
      this.dataSource = this.dataSourceBuilder.create(this.data);

      console.log(this.dataSource);
    });

  }

  SearchEmp() {
    var obj = {
      DateFrom: this.convertDateToJSONFormat(this.Search.value.Date1),
      DateTo: this.convertDateToJSONFormat(this.Search.value.Date2),
    };
    
    this.publisherService
      .PostRequest("RetrieveEmployees", obj)
      .subscribe((res: any) => {
        ;
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        var array = JSON.parse(response.ResponseMessage);

        var list = [];

        array.forEach((el) => {
          var obj = {
            data: {
              EmployeeID: el["Employee ID"],
              EmployeeName: el["Employee Name"],
              Salary: el["Employee Salary"],
              PhoneNumber: el["Employee Phone"],
              Address: el["Employee Address"],
              DeductedSalary: el["Deducted Salary"],
              deductID: el["Deduct ID"]
            },
          };
          list.push(obj);
        });

        this.data = list;
        this.dataSource = this.dataSourceBuilder.create(this.data);

        console.log(this.dataSource);
      });
  }

  AddEmployee() {
    var data = this.windowService.open(AddEmployeeComponent, {
      title: `Insert Employee`,
    });

    data.componentInstance.modalClose.subscribe(() => {
      console.log("modal close");
      this.ngOnInit();
    });

    data.onClose.subscribe((res) => {
      this.ngOnInit();
    });
  }

  AddDeduction() {
    var data = this.windowService.open(AddEmployeeSaleryDeductModalComponent, {
      title: `Salery Deduction`,
    });

    data.componentInstance.modalClose.subscribe(() => {
      console.log("modal close");
      this.ngOnInit();
    });

    data.onClose.subscribe((res) => {
      this.ngOnInit();
    });
  }

  updateEmployee(EmployeeID) {
    var SelectedData = this.data.filter(
      (a) => a.data.EmployeeID == EmployeeID
    )[0];

    var obj = {
      EmoloyeeID: SelectedData.data.EmployeeID,
      Employeename: SelectedData.data.EmployeeName,
      PhoneNumber: SelectedData.data.PhoneNumber,
      Salary: SelectedData.data.Salary,
      Address: SelectedData.data.Address,
    };

    var data = this.windowService.open(AddEmployeeComponent, {
      title: `Insert Employee`,
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

  DeleteEmployee(ID) {
    var obj = {
      EmployeeID: ID,
    };

    this.publisherService
      .PostRequest("DeleteEmployee", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));
        this.ngOnInit();
      });
  }

  convertDateToJSONFormat(date) {
    var milliseconds = date.getTime();
    return "/Date(" + milliseconds + ")/";
  }

  updateDeduction(ID) {
    
    var SelectedData = this.data.filter(
      (a) => a.data.deductID == ID
    )[0];

    var obj = {
      deductID: SelectedData.data.deductID,
      ammount: SelectedData.data.DeductedSalary,
    };

    var data = this.windowService.open(AddEmployeeSaleryDeductModalComponent, {
      title: `Update Deduction`,
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

  DeleteDeduction(ID) {
    var obj = {
      DeductionID: ID,
    };
     
    this.publisherService
      .PostRequest("DeleteDeduction", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));
        this.ngOnInit();
      });
  }

}
