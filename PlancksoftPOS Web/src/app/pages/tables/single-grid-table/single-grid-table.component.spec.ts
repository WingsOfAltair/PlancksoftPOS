import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SingleGridTableComponent } from './single-grid-table.component';

describe('SingleGridTableComponent', () => {
  let component: SingleGridTableComponent;
  let fixture: ComponentFixture<SingleGridTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SingleGridTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SingleGridTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
