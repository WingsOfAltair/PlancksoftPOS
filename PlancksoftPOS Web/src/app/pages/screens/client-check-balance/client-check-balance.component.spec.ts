import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientCheckBalanceComponent } from './client-check-balance.component';

describe('ClientCheckBalanceComponent', () => {
  let component: ClientCheckBalanceComponent;
  let fixture: ComponentFixture<ClientCheckBalanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClientCheckBalanceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClientCheckBalanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
