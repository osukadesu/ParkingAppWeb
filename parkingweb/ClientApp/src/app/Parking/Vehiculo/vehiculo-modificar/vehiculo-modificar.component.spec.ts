import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehiculoModificarComponent } from './vehiculo-modificar.component';

describe('VehiculoModificarComponent', () => {
  let component: VehiculoModificarComponent;
  let fixture: ComponentFixture<VehiculoModificarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VehiculoModificarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VehiculoModificarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
