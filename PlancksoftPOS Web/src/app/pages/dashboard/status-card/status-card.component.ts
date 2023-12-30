import { Component, Input } from '@angular/core';

@Component({
  selector: 'ngx-status-card',
  styleUrls: ['./status-card.component.scss'],
  template: `


    <nb-card *ngIf="type != 'primary'" (click)="on = !on" [ngClass]="{'off': !on}">
      <div class="icon-container">
        <div class="icon status-{{ type }}">
          <ng-content></ng-content>
        </div>
      </div>

      <div class="details">
        <div class="title h5">{{ title }}</div>
        <div class="status paragraph-2">{{ on ? 'On' : 'Off' }}</div>
      </div>
    </nb-card>

    <nb-card *ngIf="type == 'primary'" (click)="on = !on" [ngClass]="{'off': !on}">
    <div class="icon-container">
      <div class="icon status-{{ type }}">
        <ng-content></ng-content>
      </div>
    </div>

    <div class="details">
      <div class="title h5">{{ title }}</div>
      <div class="status paragraph-2">{{ on ? 'Close' : 'Open' }}</div>
    </div>
  </nb-card>
  `,
})


export class StatusCardComponent {

  @Input() title: string;
  @Input() type: string;
  @Input() on = true;
}
