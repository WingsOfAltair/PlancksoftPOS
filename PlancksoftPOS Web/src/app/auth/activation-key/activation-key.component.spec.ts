import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActivationKeyComponent } from './activation-key.component';

describe('ActivationKeyComponent', () => {
  let component: ActivationKeyComponent;
  let fixture: ComponentFixture<ActivationKeyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActivationKeyComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ActivationKeyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
