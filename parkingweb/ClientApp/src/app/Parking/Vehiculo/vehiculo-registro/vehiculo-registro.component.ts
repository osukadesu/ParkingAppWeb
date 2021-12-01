import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { VehiculoService } from 'src/app/services/vehiculo.service';
import { Vehiculo } from '../../models/vehiculo';

@Component({
  selector: 'app-vehiculo-registro',
  templateUrl: './vehiculo-registro.component.html',
  styleUrls: ['./vehiculo-registro.component.css']
})
export class VehiculoRegistroComponent implements OnInit {
  formregistro: FormGroup;
  vehiculo: Vehiculo;
  constructor(private vehiculoService: VehiculoService, private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.vehiculo = new Vehiculo();
    this.buildForm();
  }
  private buildForm() {
    this.vehiculo = new Vehiculo();
    this.vehiculo.id_vehiculo = '';
    this.vehiculo.cedula ='';
    this.vehiculo.marca = '';
    this.vehiculo.tipo_vehiculo='';
    this.vehiculo.color='';

    this.formregistro = this.formBuilder.group({
      id_vehiculo: [this.vehiculo.id_vehiculo, [Validators.required, Validators.maxLength(4), this.ValidaID]],
      cedula: [this.vehiculo.cedula, Validators.required],
      marca: [this.vehiculo.marca, Validators.required],
      tipo_vehiculo: [this.vehiculo.tipo_vehiculo,Validators.required],
      color: [this.vehiculo.color, Validators.required],
    });
  }

  private ValidaID(control: AbstractControl) {
    const cantidad = control.value;
    if (cantidad <= 0 || cantidad >= 9999) {
      return { validCantidad: true, messageCantidad: 'Cantidad menor o igual a 0' };
    }
    return null;
  }

  get control() {
    return this.formregistro.controls;
  }

  onSubmit() {
    if (this.formregistro.invalid) {
      return;
    }
    this.add();
  }

  add() {
    this.vehiculo = this.formregistro.value;
    this.vehiculoService.post(this.vehiculo).subscribe(p => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: Se ha registrado un vehiculo';
        this.vehiculo = p;
      }
    });
  }
}
