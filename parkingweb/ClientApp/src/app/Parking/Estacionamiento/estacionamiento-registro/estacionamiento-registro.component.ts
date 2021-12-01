import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { EstacionamientoService } from 'src/app/services/estacionamiento.service';
import { Estacionamiento } from '../../models/estacionamiento';

@Component({
  selector: 'app-estacionamiento-registro',
  templateUrl: './estacionamiento-registro.component.html',
  styleUrls: ['./estacionamiento-registro.component.css']
})
export class EstacionamientoRegistroComponent implements OnInit {
  formregistro: FormGroup;
  estacionamiento: Estacionamiento;
  constructor(private estacionamientoService: EstacionamientoService, private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.estacionamiento = new Estacionamiento();
    this.buildForm();
  }
  private buildForm() {
    this.estacionamiento = new Estacionamiento();
    this.estacionamiento.id_estacionamiento = '';
    this.estacionamiento.tipo_estacionamiento = '';
    this.estacionamiento.numero_cupo = '';
    this.estacionamiento.estado = 'Disponible';

    this.formregistro = this.formBuilder.group({
      id_estacionamiento: [this.estacionamiento.id_estacionamiento, [Validators.required, Validators.maxLength(4), this.ValidaID]],
      tipo_estacionamiento: [this.estacionamiento.tipo_estacionamiento, Validators.required],
      numero_cupo: [this.estacionamiento.numero_cupo, Validators.required],
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
    this.estacionamiento = this.formregistro.value;
    this.estacionamientoService.post(this.estacionamiento).subscribe(p => {
      if (p != null) {
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: Se ha registrado un estacionamiento';
        this.estacionamiento = p;
      }
    });
  }
}