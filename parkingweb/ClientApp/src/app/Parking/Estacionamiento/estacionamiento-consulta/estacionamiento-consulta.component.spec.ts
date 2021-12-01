import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EstacionamientoConsultaComponent } from './estacionamiento-consulta.component';

describe('EstacionamientoConsultaComponent', () => {
  let component: EstacionamientoConsultaComponent;
  let fixture: ComponentFixture<EstacionamientoConsultaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EstacionamientoConsultaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EstacionamientoConsultaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
