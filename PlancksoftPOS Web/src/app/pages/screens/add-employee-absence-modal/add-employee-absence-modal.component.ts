import { Component, DebugElement, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { NbDateService, NbToastrService, NbWindowRef } from "@nebular/theme";
import { PublisherService } from "../../../services/publisher.service";

@Component({
  selector: "ngx-add-employee-absence-modal",
  templateUrl: "./add-employee-absence-modal.component.html",
  styleUrls: ["./add-employee-absence-modal.component.scss"],
})
export class AddEmployeeAbsenceModalComponent implements OnInit {
  list: any;
  dataa: any;

  absence: FormGroup;
  data: any;

  constructor(
    protected dateService: NbDateService<Date>,
    private fb: FormBuilder,
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    public windowRef: NbWindowRef
  ) {}



  ngOnInit(): void {

     
    this.dataa = this.windowRef.config.context;

    this.absence = this.fb.group({
      EmployeeName: [],
      Hours: [],
      Date: [],
    });

    var list = [];

    this.publisherService
      .PostRequest("RetrieveEmployeesData", "")
      .subscribe((res: any) => {
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

    if (this.dataa.AbsenceID) {
      this.absence.patchValue({
        EmployeeName: this.dataa.EmployeeID,
        Hours: this.dataa.AbsenceHours,
        Date: this.dataa.AbsenceDate,
      });
    }
  }

  convertDateToJSONFormat(date) {
    var milliseconds = date.getTime();
    return "/Date(" + milliseconds + ")/";
  }

  submit() {
    if (this.absence.valid) {
      console.log(this.absence.value);

      var obj = {
        EmployeeID: this.absence.value.EmployeeName,
        Hours: parseInt(this.absence.value.Hours),
        Date: this.convertDateToJSONFormat(this.absence.value.Date),
      };

      this.publisherService
        .PostRequest("InsertAbsence", obj)
        .subscribe((res: any) => {
          console.log(JSON.parse(res));
        });
    } else {
      this.toastrService.danger("Try Again", "Error");
    }

    console.log(this.absence.value);
    this.windowRef.close("");
  }
  
  update() {
    if (this.absence.valid) {
      console.log(this.absence.value);

      var obj = {
        AbsenceID: this.dataa.AbsenceID,
        Hours: parseInt(this.absence.value.Hours),
      };

      this.publisherService
        .PostRequest("UpdateAbsence", obj)
        .subscribe((res: any) => {
          console.log(JSON.parse(res));
        });
    } else {
      this.toastrService.danger("Try Again", "Error");
    }

    console.log(this.absence.value);
    this.windowRef.close("");
  }
}
