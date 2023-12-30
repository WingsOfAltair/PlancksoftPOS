import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportExportCapitalComponent } from './import-export-capital.component';

describe('ImportExportCapitalComponent', () => {
  let component: ImportExportCapitalComponent;
  let fixture: ComponentFixture<ImportExportCapitalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImportExportCapitalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ImportExportCapitalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
