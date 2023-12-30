import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlaramComponent } from './alaram.component';

describe('AlaramComponent', () => {
  let component: AlaramComponent;
  let fixture: ComponentFixture<AlaramComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AlaramComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AlaramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
