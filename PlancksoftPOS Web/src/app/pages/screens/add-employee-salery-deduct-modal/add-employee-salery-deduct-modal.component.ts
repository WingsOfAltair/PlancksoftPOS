import { Component, OnInit, Output, EventEmitter } from "@angular/core";
import { NbWindowRef, NbWindowService } from "@nebular/theme";
import { PublisherService } from "../../../services/publisher.service";
import { FormBuilder, FormGroup } from "@angular/forms";

@Component({
  selector: "ngx-add-employee-salery-deduct-modal",
  templateUrl: "./add-employee-salery-deduct-modal.component.html",
  styleUrls: ["./add-employee-salery-deduct-modal.component.scss"],
})
export class AddEmployeeSaleryDeductModalComponent implements OnInit {
  firstFormGroup: FormGroup;
  data: any[];
  dataa: any;

  constructor(
    private windowService: NbWindowService,
    private publisherService: PublisherService,
    private fb: FormBuilder,
    public windowRef: NbWindowRef
  ) {}

  @Output() modalClose = new EventEmitter();
  
  closeModal() {
    this.modalClose.emit(); // Emit custom event
    this.windowRef.close("");
}

  ngOnInit(): void {
    ;
    this.dataa = this.windowRef.config.context;

    this.firstFormGroup = this.fb.group({
      EmployeeName: [],
      date: [],
      Salery: [],
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
              // EmployeeAddress: el["Employee Address"],
              EmployeeID: el["Employee ID"],
              EmployeeName: el["Employee Name"],
            },
          };
          list.push(obj);
        });

        this.data = list;
      });

    if (this.dataa.deductID) {
      this.firstFormGroup.get("Salery").setValue(this.dataa.ammount);
    }
  }

  convertDateToJSONFormat(date) {
    var milliseconds = date.getTime();
    return "/Date(" + milliseconds + ")/";
  }

  SubmitData() {
    var obj = {
      EmployeeID: this.firstFormGroup.value.EmployeeName,
      Date: this.convertDateToJSONFormat(this.firstFormGroup.value.date),
      Deduction: this.firstFormGroup.value.Salery,
    };

    this.publisherService
      .PostRequest("InsertDeduction", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        this.closeModal();
      });
  }

  updateData() {
    var obj = {
      DeductionID: this.dataa.deductID,
      DeductionAmount: this.firstFormGroup.value.Salery,
    };

    this.publisherService
      .PostRequest("UpdateDeduction", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));
        
        this.closeModal();
      });
  }
}
