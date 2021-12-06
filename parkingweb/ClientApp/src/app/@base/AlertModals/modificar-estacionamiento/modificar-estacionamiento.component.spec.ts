import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModificarEstacionamientoComponent } from './modificar-estacionamiento.component';

describe('ModificarEstacionamientoComponent', () => {
  let component: ModificarEstacionamientoComponent;
  let fixture: ComponentFixture<ModificarEstacionamientoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModificarEstacionamientoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModificarEstacionamientoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
