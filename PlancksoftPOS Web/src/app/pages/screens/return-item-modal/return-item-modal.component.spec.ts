import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReturnItemModalComponent } from './return-item-modal.component';

describe('ReturnItemModalComponent', () => {
  let component: ReturnItemModalComponent;
  let fixture: ComponentFixture<ReturnItemModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReturnItemModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReturnItemModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
