import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PerivousBillComponent } from './perivous-bill.component';

describe('PerivousBillComponent', () => {
  let component: PerivousBillComponent;
  let fixture: ComponentFixture<PerivousBillComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PerivousBillComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PerivousBillComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
