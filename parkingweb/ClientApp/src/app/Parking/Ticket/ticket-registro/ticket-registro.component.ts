import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { TicketService } from 'src/app/services/ticket.service';
import { Ticket } from '../../models/ticket';

@Component({
  selector: 'app-ticket-registro',
  templateUrl: './ticket-registro.component.html',
  styleUrls: ['./ticket-registro.component.css']
})
export class TicketRegistroComponent implements OnInit {
  formregistro: FormGroup;
  ticket: Ticket;
  constructor(private ticketService: TicketService, private formBuilder: FormBuilder,
    private modalService: NgbModal) { }

  ngOnInit() {
    this.ticket = new Ticket();
    this.buildForm();
  }
  private buildForm() {
    this.ticket = new Ticket();
    this.ticket.id_ticket = '';
    this.ticket.cedula = '';
    this.ticket.id_vehiculo = '';
    this.ticket.id_estacionamiento = '';
    this.ticket.fecha_elaboracion;
    this.ticket.fecha_salida;
    this.ticket.subtotal;
    this.ticket.iva;
    this.ticket.total;

    this.formregistro = this.formBuilder.group({
      id_ticket: [this.ticket.id_ticket, [Validators.required, Validators.maxLength(4), this.ValidaID]],
      cedula: [this.ticket.cedula, Validators.required],
      id_vehiculo: [this.ticket.id_vehiculo, Validators.required],
      id_estacionamiento: [this.ticket.id_estacionamiento,Validators.required],
      fecha_elaboracion: [this.ticket.fecha_elaboracion, Validators.required],
      fecha_salida: [this.ticket.fecha_salida, Validators.required],
      subtotal: [this.ticket.subtotal,Validators.required],
      iva: [this.ticket.iva, Validators.required],
      total: [this.ticket.total, Validators.required],
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
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: Se ha registrado un ticket';
        this.ticket = p;
      }
    });
  }
}
