import { DatePipe } from "@angular/common";
import { Output, EventEmitter, Component, OnInit } from "@angular/core";
import {
  NbDateService,
  NbDialogService,
  NbToastrService,
  NbWindowRef,
} from "@nebular/theme";
import { PublisherService } from "../../../services/publisher.service";
import { FormBuilder, FormGroup } from "@angular/forms";

@Component({
  selector: "ngx-add-expense",
  templateUrl: "./add-expense.component.html",
  styleUrls: ["./add-expense.component.scss"],
})
export class AddExpenseComponent implements OnInit {
  formgroup: FormGroup;
  jsonDate: any;

  constructor(
    private dialogService: NbDialogService,
    protected dateService: NbDateService<Date>,
    private fb: FormBuilder,
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    private windowRef: NbWindowRef,
    public datepipe: DatePipe
  ) {}

    @Output() modalClose = new EventEmitter();
  
    closeModal() {
      this.modalClose.emit(); // Emit custom event
      this.windowRef.close("");
    }

  ngOnInit(): void {
    this.jsonDate = this.datepipe.transform(new Date(), "MM/dd/yyyy");

    console.log(this.jsonDate);

    this.formgroup = this.fb.group({
      Expensename: [""],
      Expenseamount: [""],
    });

    var date = new Date();
    this.jsonDate = this.convertDateToJSONFormat(date);
    console.log(this.jsonDate);
    
    console.log(this.windowRef.config.windowClass)
    
  }

  SubmitData() {
    if (this.formgroup.valid) {
      console.log(this.formgroup.value);

      var obj = {
        ExpenseName: this.formgroup.value.Expensename,
        ExpenseCost: parseInt(this.formgroup.value.Expenseamount),
        EmployeeName: "1",
        Date: this.convertDateToJSONFormat(new Date()),
      };

      ;
      this.publisherService
        .PostRequest("InsertExpense", obj)
        .subscribe((res: any) => {
          console.log(JSON.parse(res));
        });
    } else {
      this.toastrService.danger("Try Again", "Error");
    }

    this.closeModal();

  }

  convertDateToJSONFormat(date) {
    
    var milliseconds = date.getTime();
    return "/Date(" + milliseconds + ")/";
  }
}
