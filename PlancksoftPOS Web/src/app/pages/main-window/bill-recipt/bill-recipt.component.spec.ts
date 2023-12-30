import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BillReciptComponent } from './bill-recipt.component';

describe('BillReciptComponent', () => {
  let component: BillReciptComponent;
  let fixture: ComponentFixture<BillReciptComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BillReciptComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BillReciptComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
