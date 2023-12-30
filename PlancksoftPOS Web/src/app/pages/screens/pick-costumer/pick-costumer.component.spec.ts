import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PickCostumerComponent } from './pick-costumer.component';

describe('PickCostumerComponent', () => {
  let component: PickCostumerComponent;
  let fixture: ComponentFixture<PickCostumerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PickCostumerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PickCostumerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
