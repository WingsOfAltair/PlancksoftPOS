import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CloseModelRegisterComponent } from './close-model-register.component';

describe('CloseModelRegisterComponent', () => {
  let component: CloseModelRegisterComponent;
  let fixture: ComponentFixture<CloseModelRegisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CloseModelRegisterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CloseModelRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
