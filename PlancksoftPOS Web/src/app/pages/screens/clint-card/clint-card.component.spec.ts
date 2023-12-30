import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClintCardComponent } from './clint-card.component';

describe('ClintCardComponent', () => {
  let component: ClintCardComponent;
  let fixture: ComponentFixture<ClintCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClintCardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClintCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
