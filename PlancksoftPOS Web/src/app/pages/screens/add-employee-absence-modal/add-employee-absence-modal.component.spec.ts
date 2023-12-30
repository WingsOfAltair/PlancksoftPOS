import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEmployeeAbsenceModalComponent } from './add-employee-absence-modal.component';

describe('AddEmployeeAbsenceModalComponent', () => {
  let component: AddEmployeeAbsenceModalComponent;
  let fixture: ComponentFixture<AddEmployeeAbsenceModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEmployeeAbsenceModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEmployeeAbsenceModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
