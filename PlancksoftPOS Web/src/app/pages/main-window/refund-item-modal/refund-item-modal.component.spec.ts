import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RefundItemModalComponent } from './refund-item-modal.component';

describe('RefundItemModalComponent', () => {
  let component: RefundItemModalComponent;
  let fixture: ComponentFixture<RefundItemModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RefundItemModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RefundItemModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
