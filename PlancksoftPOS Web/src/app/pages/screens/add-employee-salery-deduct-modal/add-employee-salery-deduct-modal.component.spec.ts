import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEmployeeSaleryDeductModalComponent } from './add-employee-salery-deduct-modal.component';

describe('AddEmployeeSaleryDeductModalComponent', () => {
  let component: AddEmployeeSaleryDeductModalComponent;
  let fixture: ComponentFixture<AddEmployeeSaleryDeductModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEmployeeSaleryDeductModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEmployeeSaleryDeductModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
