import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorsDefinationComponent } from './vendors-defination.component';

describe('VendorsDefinationComponent', () => {
  let component: VendorsDefinationComponent;
  let fixture: ComponentFixture<VendorsDefinationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VendorsDefinationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VendorsDefinationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
