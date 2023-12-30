import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportExportFormComponent } from './import-export-form.component';

describe('ImportExportFormComponent', () => {
  let component: ImportExportFormComponent;
  let fixture: ComponentFixture<ImportExportFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImportExportFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ImportExportFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
