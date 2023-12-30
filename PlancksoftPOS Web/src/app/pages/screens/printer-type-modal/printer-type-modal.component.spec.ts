import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrinterTypeModalComponent } from './printer-type-modal.component';

describe('PrinterTypeModalComponent', () => {
  let component: PrinterTypeModalComponent;
  let fixture: ComponentFixture<PrinterTypeModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrinterTypeModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrinterTypeModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
