import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'ngx-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.scss']
})
export class PaymentComponent implements OnInit {

  options = [
    { value: 'This is value 1', label: 'Cash Payment' },
    { value: 'This is value 2', label: 'Visa Payment' },
    
  ];
  option;

  showTextField: boolean = false;
  textFieldValue: string = '';

  toggleTextField() {
    this.showTextField = !this.showTextField;
  }

  constructor() { }

  ngOnInit(): void {
  }

}
