import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EstacionamientoRegistroComponent } from './estacionamiento-registro.component';

describe('EstacionamientoRegistroComponent', () => {
  let component: EstacionamientoRegistroComponent;
  let fixture: ComponentFixture<EstacionamientoRegistroComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EstacionamientoRegistroComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EstacionamientoRegistroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
