import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrinterModalComponent } from './printer-modal.component';

describe('PrinterModalComponent', () => {
  let component: PrinterModalComponent;
  let fixture: ComponentFixture<PrinterModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrinterModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrinterModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
