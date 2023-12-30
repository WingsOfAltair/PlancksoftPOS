import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SoldItemQuantificationComponent } from './sold-item-quantification.component';

describe('SoldItemQuantificationComponent', () => {
  let component: SoldItemQuantificationComponent;
  let fixture: ComponentFixture<SoldItemQuantificationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SoldItemQuantificationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SoldItemQuantificationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
