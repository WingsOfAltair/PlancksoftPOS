import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientAddModalComponent } from './client-add-modal.component';

describe('ClientAddModalComponent', () => {
  let component: ClientAddModalComponent;
  let fixture: ComponentFixture<ClientAddModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClientAddModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClientAddModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
