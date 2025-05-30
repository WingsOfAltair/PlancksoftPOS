import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorAddModalComponent } from './vendor-add-modal.component';

describe('VendorAddModalComponent', () => {
  let component: VendorAddModalComponent;
  let fixture: ComponentFixture<VendorAddModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VendorAddModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VendorAddModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
