import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { RegistrosComponent } from 'src/app/@base/AlertModals/registros/registros.component';
import { ClienteService } from 'src/app/services/cliente.service';
import { VehiculoService } from 'src/app/services/vehiculo.service';
import { Cliente } from '../../models/cliente';
import { Vehiculo } from '../../models/vehiculo';

@Component({
  selector: 'app-vehiculo-registro',
  templateUrl: './vehiculo-registro.component.html',
  styleUrls: ['./vehiculo-registro.component.css']
})
export class VehiculoRegistroComponent implements OnInit {
  precio: number = 0;
  formRegistro: FormGroup;
  vehiculo: Vehiculo;
  clientes: Cliente[]=[];
  constructor(private vehiculoService: VehiculoService, private clienteService:ClienteService, private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.vehiculo = new Vehiculo();
    this.vehiculo.precio = 0;
    this.buildForm();
    this.ConsultarClientes();
  }
  private buildForm() {
    this.vehiculo = new Vehiculo();
    this.vehiculo.idVehiculo = '';
    this.vehiculo.cedula ='';
    this.vehiculo.marca = '';
    this.vehiculo.tipo='';
    this.vehiculo.color='';

    this.formRegistro = this.formBuilder.group({
      idVehiculo: [this.vehiculo.idVehiculo, [Validators.required, Validators.maxLength(4), this.ValidaID]],
      cedula: [this.vehiculo.cedula, Validators.required],
      marca: [this.vehiculo.marca, Validators.required],
      tipo: [this.vehiculo.tipo,Validators.required],
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

    asignarPrecio()
    {
      let tipoVehiculo = this.formRegistro.value.tipo;
      this.precio = tipoVehiculo =="carro" ? 2000 : tipoVehiculo == "bici" ? 500 : tipoVehiculo == "moto" ? 1000 : 0;
    }
    
  
  ConsultarClientes()
  {
    this.clienteService.get().subscribe(result => {
          this.clientes = result;
        });
  }

  get control() {
    return this.formRegistro.controls;
  }

  onSubmit() {
    if (this.formRegistro.invalid) {
      return;
    }
    this.add();
  }

  add() {
    this.vehiculo = this.formRegistro.value;
    this.vehiculo.precio = this.precio;
    this.vehiculoService.post(this.vehiculo).subscribe(p => {
      if (p != null) {
        const messageBox = this.modalService.open(RegistrosComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: Se ha registrado un vehiculo';
        this.vehiculo = p;
      }
    });
  }
}
