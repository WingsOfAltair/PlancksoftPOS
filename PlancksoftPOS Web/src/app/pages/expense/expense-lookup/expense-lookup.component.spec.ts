import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExpenseLookupComponent } from './expense-lookup.component';

describe('ExpenseLookupComponent', () => {
  let component: ExpenseLookupComponent;
  let fixture: ComponentFixture<ExpenseLookupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExpenseLookupComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExpenseLookupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
