import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrinterTypeComponent } from './printer-type.component';

describe('PrinterTypeComponent', () => {
  let component: PrinterTypeComponent;
  let fixture: ComponentFixture<PrinterTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrinterTypeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrinterTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
