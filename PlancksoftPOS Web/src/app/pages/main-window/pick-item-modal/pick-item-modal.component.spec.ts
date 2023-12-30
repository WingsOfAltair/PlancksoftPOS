import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PickItemModalComponent } from './pick-item-modal.component';

describe('PickItemModalComponent', () => {
  let component: PickItemModalComponent;
  let fixture: ComponentFixture<PickItemModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PickItemModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PickItemModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
