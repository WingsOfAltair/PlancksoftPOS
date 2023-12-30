import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImcomingOutgoingsaleComponent } from './imcoming-outgoingsale.component';

describe('ImcomingOutgoingsaleComponent', () => {
  let component: ImcomingOutgoingsaleComponent;
  let fixture: ComponentFixture<ImcomingOutgoingsaleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImcomingOutgoingsaleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ImcomingOutgoingsaleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
