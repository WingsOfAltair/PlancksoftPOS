import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FavroiteCategoryComponent } from './favroite-category.component';

describe('FavroiteCategoryComponent', () => {
  let component: FavroiteCategoryComponent;
  let fixture: ComponentFixture<FavroiteCategoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FavroiteCategoryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FavroiteCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
