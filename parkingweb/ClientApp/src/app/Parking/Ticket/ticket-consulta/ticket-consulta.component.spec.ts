import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketConsultaComponent } from './ticket-consulta.component';

describe('TicketConsultaComponent', () => {
  let component: TicketConsultaComponent;
  let fixture: ComponentFixture<TicketConsultaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TicketConsultaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TicketConsultaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
