import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddWearhouseComponent } from './add-wearhouse.component';

describe('AddWearhouseComponent', () => {
  let component: AddWearhouseComponent;
  let fixture: ComponentFixture<AddWearhouseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddWearhouseComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddWearhouseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
