import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrinterSettingComponent } from './printer-setting.component';

describe('PrinterSettingComponent', () => {
  let component: PrinterSettingComponent;
  let fixture: ComponentFixture<PrinterSettingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrinterSettingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrinterSettingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
