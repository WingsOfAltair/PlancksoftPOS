import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PickCostumerLookupComponent } from './pick-costumer-lookup.component';

describe('PickCostumerLookupComponent', () => {
  let component: PickCostumerLookupComponent;
  let fixture: ComponentFixture<PickCostumerLookupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PickCostumerLookupComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PickCostumerLookupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
