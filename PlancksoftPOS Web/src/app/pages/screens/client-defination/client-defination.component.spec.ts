import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientDefinationComponent } from './client-defination.component';

describe('ClientDefinationComponent', () => {
  let component: ClientDefinationComponent;
  let fixture: ComponentFixture<ClientDefinationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClientDefinationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClientDefinationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
