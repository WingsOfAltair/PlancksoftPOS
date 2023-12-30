import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PublisherService } from '../../../services/publisher.service';
import { NbToastrService, NbWindowRef, NbWindowService } from '@nebular/theme';

@Component({
  selector: 'ngx-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.scss']
})
export class AddEmployeeComponent implements OnInit {

  AddEmployeeData: FormGroup
  data:any

  constructor(
    private fb:FormBuilder,
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    public windowRef: NbWindowRef
  
  ) {}

  ngOnInit(): void {

    
    this.data = this.windowRef.config.context;

    console.log(this.data);

    this.AddEmployeeData = this.fb.group({
      EmployeeName:[''],
      Salary:[''],
      EmployeePhone:[''],
      EmployeeAddress:[''],
    })

    this.AddEmployeeData.patchValue({
      EmployeeName: this.data.Employeename,
      Salary: this.data.Salary,
      EmployeePhone: this.data.PhoneNumber,
      EmployeeAddress: this.data.Address,
    })



  }



  RegisterEmployeeData() {

    if (this.AddEmployeeData.valid) {
      console.log(this.AddEmployeeData.value);

      var obj = {
        EmployeeName: this.AddEmployeeData.value.EmployeeName,
        Salary: parseInt(this.AddEmployeeData.value.Salary),
        Phone: this.AddEmployeeData.value.EmployeePhone,
        Address: this.AddEmployeeData.value.EmployeeAddress ,
      };

      
      this.publisherService
        .PostRequest("InsertEmployee", obj)
        .subscribe((res: any) => {
          console.log(JSON.parse(res));
        });
    } else {
      this.toastrService.danger("Try Again", "Error");
    }

    this.windowRef.close("");
  }

  UpdateEmployeeData() {

    if (this.AddEmployeeData.valid) {
      console.log(this.AddEmployeeData.value);

      var obj = {
        EmployeeID: this.data.EmoloyeeID,
        EmployeeName: this.AddEmployeeData.value.EmployeeName,
        Salary: parseInt(this.AddEmployeeData.value.Salary),
        Phone: this.AddEmployeeData.value.EmployeePhone,
        Address: this.AddEmployeeData.value.EmployeeAddress ,
      };

      this.publisherService
        .PostRequest("UpdateEmployee", obj)
        .subscribe((res: any) => {
          console.log(JSON.parse(res));
        });
    } else {
      this.toastrService.danger("Try Again", "Error");
    }
    this.windowRef.close("");

    console.log(this.AddEmployeeData.value);
  }
}
