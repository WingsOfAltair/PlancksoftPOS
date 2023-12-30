import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WearhouseQuantificationComponent } from './wearhouse-quantification.component';

describe('WearhouseQuantificationComponent', () => {
  let component: WearhouseQuantificationComponent;
  let fixture: ComponentFixture<WearhouseQuantificationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WearhouseQuantificationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WearhouseQuantificationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
