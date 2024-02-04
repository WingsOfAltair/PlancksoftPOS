import { Component, Input } from '@angular/core';

@Component({
  selector: 'ngx-status-card',
  styleUrls: ['./status-card.component.scss'],
  template: `


    <nb-card *ngIf="type != 'primary'" [ngClass]="{'off': !registerOn}">
      <div class="icon-container">
        <div class="icon status-{{ type }}">
          <ng-content></ng-content>
        </div>
      </div>

      <div class="details">
        <div class="title h5">{{ title }}</div>
        <div class="status paragraph-2">{{ registerOn ? 'On' : 'Off' }}</div>
      </div>
    </nb-card>

    <nb-card *ngIf="type == 'primary'" [ngClass]="{'off': !registerOn}">
    <div class="icon-container">
      <div class="icon status-{{ type }}">
        <ng-content></ng-content>
      </div>
    </div>

    <div class="details">
      <div class="title h5">{{ title }}</div>
      <div class="status paragraph-2">{{ registerOn ? 'Open' : 'Closed' }}</div>
    </div>
  </nb-card>
  `,
})


export class StatusCardComponent {

  @Input() title: string;
  @Input() type: string;
  @Input() registerOn = JSON.parse(localStorage.getItem('registerOn'));;
}
