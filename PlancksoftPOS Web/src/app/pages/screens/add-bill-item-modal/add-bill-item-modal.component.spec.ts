import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBillItemModalComponent } from './add-bill-item-modal.component';

describe('AddBillItemModalComponent', () => {
  let component: AddBillItemModalComponent;
  let fixture: ComponentFixture<AddBillItemModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddBillItemModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddBillItemModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
