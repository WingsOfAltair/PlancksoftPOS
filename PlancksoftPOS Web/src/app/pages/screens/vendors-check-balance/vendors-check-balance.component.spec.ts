import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorsCheckBalanceComponent } from './vendors-check-balance.component';

describe('VendorsCheckBalanceComponent', () => {
  let component: VendorsCheckBalanceComponent;
  let fixture: ComponentFixture<VendorsCheckBalanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VendorsCheckBalanceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VendorsCheckBalanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
