import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddItemTypeComponent } from './add-item-type.component';

describe('AddItemTypeComponent', () => {
  let component: AddItemTypeComponent;
  let fixture: ComponentFixture<AddItemTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddItemTypeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddItemTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
