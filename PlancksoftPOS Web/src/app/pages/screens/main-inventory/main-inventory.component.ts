import { Component, OnInit } from '@angular/core';
import { NbDateService } from '@nebular/theme';

@Component({
  selector: 'ngx-main-inventory',
  templateUrl: './main-inventory.component.html',
  styleUrls: ['./main-inventory.component.scss']
})
export class MainInventoryComponent implements OnInit {

  min: Date;
  max: Date;

  constructor(protected dateService: NbDateService<Date>) { 
    this.min = this.dateService.addDay(this.dateService.today(), -5);
    this.max = this.dateService.addDay(this.dateService.today(), 5);
  }

  ngOnInit(): void {
  }

}
