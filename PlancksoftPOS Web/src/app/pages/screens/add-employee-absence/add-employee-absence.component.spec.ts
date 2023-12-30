import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEmployeeAbsenceComponent } from './add-employee-absence.component';

describe('AddEmployeeAbsenceComponent', () => {
  let component: AddEmployeeAbsenceComponent;
  let fixture: ComponentFixture<AddEmployeeAbsenceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEmployeeAbsenceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEmployeeAbsenceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
