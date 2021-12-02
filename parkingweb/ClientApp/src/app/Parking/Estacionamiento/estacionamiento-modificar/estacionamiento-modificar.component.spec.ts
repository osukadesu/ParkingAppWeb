import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EstacionamientoModificarComponent } from './estacionamiento-modificar.component';

describe('EstacionamientoModificarComponent', () => {
  let component: EstacionamientoModificarComponent;
  let fixture: ComponentFixture<EstacionamientoModificarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EstacionamientoModificarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EstacionamientoModificarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
