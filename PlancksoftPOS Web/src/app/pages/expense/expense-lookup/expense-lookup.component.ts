import { Component, OnInit } from "@angular/core";
import {
  NbDateService,
  NbDialogService,
  NbSortDirection,
  NbSortRequest,
  NbToastrService,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
  NbWindowService,
} from "@nebular/theme";
import { SmartTableData } from "../../../@core/data/smart-table";
import { LocalDataSource } from "ng2-smart-table";
import { FormBuilder, FormGroup } from "@angular/forms";
import { PublisherService } from "../../../services/publisher.service";
import { DatePipe } from "@angular/common";
import { AddExpenseModalComponent } from "../add-expense-modal/add-expense-modal.component";
import { AddExpenseComponent } from "../add-expense/add-expense.component";

@Component({
  selector: "ngx-expense-lookup",
  templateUrl: "./expense-lookup.component.html",
  styleUrls: ["./expense-lookup.component.scss"],
})
export class ExpenseLookupComponent implements OnInit {
  Expense: FormGroup;

  message: any;
  data: any;
  employee: any;

  defaultColumns = [
    "ExpenseID",
    "ExpenseName",
    "ExpenseCost",
    "UserID",
    "ExpenseDate",
    "CurrentQuantity",
  ];
  allColumns = [...this.defaultColumns];

  dataSource: NbTreeGridDataSource<any>;

  sortColumn: string;
  sortDirection: NbSortDirection = NbSortDirection.NONE;

  constructor(
    private service: SmartTableData,
    private dialogService: NbDialogService,
    protected dateService: NbDateService<Date>,
    private fb: FormBuilder,
    private publisherService: PublisherService,
    private windowService: NbWindowService,
    private toastrService: NbToastrService,
    public datepipe: DatePipe,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>
  ) {}

  onDeleteConfirm(event): void {
    if (window.confirm("Are you sure you want to delete?")) {
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }

  convertDateToJSONFormat(date) {
    var milliseconds = date.getTime();
    return "/Date(" + milliseconds + ")/";
  }

  ngOnInit(): void {
    this.Expense = this.fb.group({
      Expensename: [],
      Employeename: [],
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
              
            },
          };
          list.push(obj);
        });
        this.data = list;

        console.log(this.dataSource);
      });

    var obj = {
      Date1: new Date(new Date(this.Expense.value.Date1).setHours(0, 0, 0, 0)),
      Date2: new Date(new Date(this.Expense.value.Date2).setHours(23, 59, 59, 999)),
      ExpenseName: "",
      EmployeeID: "",
    };

    this.publisherService
      .PostRequest("SearchExpenses", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        var array = JSON.parse(response.ResponseMessage);

        var list = [];

        array.forEach((el) => {
          const date = new Date(el["Expense Date"]);
          const formattedDate = date.toLocaleString('en-US', {
            year: 'numeric',
            month: '2-digit',
            day: '2-digit',
            hour: '2-digit',
            minute: '2-digit',
            second: '2-digit',
            hour12: true, // 12-hour format
          });
          var obj = {
            data: {
              // EmployeeAddress: el["Employee Address"],
              ExpenseID: el["Expense ID"],
              ExpanseName: el["Expense Name"],
              cost: el["Expense Cost"],
              UserId: el["Employee ID"],
              Date: formattedDate,
              Current: el["Current"],
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

  // var error = "Could not Search Expenses.";

  SearchData() {
    var obj = {
      Date1: new Date(new Date(this.Expense.value.Date1).setHours(0, 0, 0, 0)),
      Date2: new Date(new Date(this.Expense.value.Date2).setHours(23, 59, 59, 999)),
      ExpenseName: this.Expense.value.Expensename,
      EmployeeID: this.employee,
    };

    this.publisherService
      .PostRequest("SearchExpenses", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        var array = JSON.parse(response.ResponseMessage);

        var list = [];

        array.forEach((el) => {
          const date = new Date(el["Expense Date"]);
          const formattedDate = date.toLocaleString('en-US', {
            year: 'numeric',
            month: '2-digit',
            day: '2-digit',
            hour: '2-digit',
            minute: '2-digit',
            second: '2-digit',
            hour12: true, // 12-hour format
          });
          var obj = {
            data: {
              // EmployeeAddress: el["Employee Address"],
              ExpenseID: el["Expense ID"],
              ExpanseName: el["Expense Name"],
              cost: el["Expense Cost"],
              UserId: el["Employee ID"],
              Date: formattedDate,
              Current: el["Current"],
            },
          };
          list.push(obj);
        });

        this.data = list;
        this.dataSource = this.dataSourceBuilder.create(this.data);

        console.log(this.dataSource);
      });
  }

  button() {
    var data = { id: 1, name: "hanzalla" };
    var dt = this.windowService.open(AddExpenseComponent, {
      title: `Insert Expense`,
      context: data,
    });

    dt.onClose.subscribe((res) => {
      this.ngOnInit();
    });
  }

  onSelectChange(newValue: any) {
    console.log(newValue);

    this.employee = newValue;
  }
}
