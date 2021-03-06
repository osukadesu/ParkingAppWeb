import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { RegistrosComponent } from 'src/app/@base/AlertModals/registros/registros.component';
import { ClienteService } from 'src/app/services/cliente.service';
import { EstacionamientoService } from 'src/app/services/estacionamiento.service';
import { TicketService } from 'src/app/services/ticket.service';
import { VehiculoService } from 'src/app/services/vehiculo.service';
import { Cliente } from '../../models/cliente';
import { Estacionamiento } from '../../models/estacionamiento';
import { Ticket } from '../../models/ticket';
import { Vehiculo } from '../../models/vehiculo';

@Component({
  selector: 'app-ticket-registro',
  templateUrl: './ticket-registro.component.html',
  styleUrls: ['./ticket-registro.component.css']
})
export class TicketRegistroComponent implements OnInit {
  formregistro: FormGroup;
  ticket: Ticket;
  clientes: Cliente[]=[];
  vehiculos: Vehiculo[]=[];
  estacionamientos: Estacionamiento[]=[];
  constructor(private ticketService: TicketService, private clienteService: ClienteService, private vehiculoService: VehiculoService, private estacionamientoService: EstacionamientoService, private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.ticket = new Ticket();
    this.buildForm();
    this.ConsultarClientes();
    this.ConsultarVehiculos();
    this.ConsultarEstacionamientos();
  }
  
  private buildForm() {
    this.ticket = new Ticket();
    this.ticket.idTicket = '';
    this.ticket.cedula = '';
    this.ticket.idVehiculo = '';
    this.ticket.idEstacionamiento = '';
    this.ticket.fechaElaboracion;
    this.ticket.fechaSalida;

    this.formregistro = this.formBuilder.group({
      idTicket: [this.ticket.idTicket, [Validators.required, Validators.maxLength(4), this.ValidaID]],
      cedula: [this.ticket.cedula, Validators.required],
      idVehiculo: [this.ticket.idVehiculo, Validators.required],
      idEstacionamiento: [this.ticket.idEstacionamiento,Validators.required],
      fechaElaboracion: [this.ticket.fechaElaboracion, Validators.required],
      fechaSalida: [this.ticket.fechaSalida, Validators.required],
    });
  }


  ConsultarClientes()
  {
    this.clienteService.get().subscribe(result => {
          this.clientes = result;
        });
  }

  ConsultarEstacionamientos()
  {
    this.estacionamientoService.get().subscribe(result => {
          this.estacionamientos = result;
        });
  }

  ConsultarVehiculos()
  {
    this.vehiculoService.get().subscribe(result => {
          this.vehiculos = result;
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
    this.ticket = this.formregistro.value;
    this.ticketService.post(this.ticket).subscribe(p => {
      if (p != null) {
        const messageBox = this.modalService.open(RegistrosComponent)
        messageBox.componentInstance.title = "Resultado Operaci??n";
        messageBox.componentInstance.cuerpo = 'Info: Se ha registrado un ticket';
        this.ticket = p;
      }
    });
  }
}
