import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PickClientComponent } from './pick-client.component';

describe('PickClientComponent', () => {
  let component: PickClientComponent;
  let fixture: ComponentFixture<PickClientComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PickClientComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PickClientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
