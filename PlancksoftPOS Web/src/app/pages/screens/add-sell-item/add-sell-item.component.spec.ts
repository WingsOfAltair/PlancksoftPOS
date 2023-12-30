import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddSellItemComponent } from './add-sell-item.component';

describe('AddSellItemComponent', () => {
  let component: AddSellItemComponent;
  let fixture: ComponentFixture<AddSellItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddSellItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddSellItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
