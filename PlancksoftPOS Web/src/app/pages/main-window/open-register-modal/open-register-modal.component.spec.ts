import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OpenRegisterModalComponent } from './open-register-modal.component';

describe('OpenRegisterModalComponent', () => {
  let component: OpenRegisterModalComponent;
  let fixture: ComponentFixture<OpenRegisterModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OpenRegisterModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OpenRegisterModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
