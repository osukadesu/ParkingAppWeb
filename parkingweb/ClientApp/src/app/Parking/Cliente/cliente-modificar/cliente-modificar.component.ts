import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ModificarClienteComponent } from 'src/app/@base/AlertModals/modificar-cliente/modificar-cliente.component';
import { RegistrosComponent } from 'src/app/@base/AlertModals/registros/registros.component';
import { ClienteService } from 'src/app/services/cliente.service';
import { Cliente } from '../../models/cliente';

@Component({
  selector: 'app-cliente-modificar',
  templateUrl: './cliente-modificar.component.html',
  styleUrls: ['./cliente-modificar.component.css']
})
export class ClienteModificarComponent implements OnInit {

  cliente: Cliente;
  constructor(private clienteService: ClienteService, private rutaActiva: ActivatedRoute, private modalService: NgbModal) { }

  ngOnInit() {
    this.cliente = new Cliente();
    const id = this.rutaActiva.snapshot.params.identificacion;
    this.clienteService.getId(id).subscribe(p => {
      this.cliente = p;
      if (p != null) {
        const messageBox = this.modalService.open(ModificarClienteComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: puede actualizar los datos del cliente';
        messageBox.componentInstance.cuerpo2 = 'Datos del cliente:';
        messageBox.componentInstance.cedula = 'Cedula: '+this.cliente.cedula;
        messageBox.componentInstance.nombre = 'Nombre: '+this.cliente.nombre;
        messageBox.componentInstance.apellido = 'Apellido: '+this.cliente.apellido;

      }
      else {
        const messageBox = this.modalService.open(ModificarClienteComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: Error al consultar el cliente: '+this.cliente.cedula;
      }
    });
  }

  update() {
    this.clienteService.put(this.cliente).subscribe(p => {
      const messageBox = this.modalService.open(ModificarClienteComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: se ha actualizado los datos del cliente';
        messageBox.componentInstance.cuerpo2 = 'Datos del cliente:';
        messageBox.componentInstance.cedula = 'Cedula: '+this.cliente.cedula;
        messageBox.componentInstance.nombre = 'Nombre: '+this.cliente.nombre;
        messageBox.componentInstance.apellido = 'Apellido: '+this.cliente.apellido;
    });
  }
}
