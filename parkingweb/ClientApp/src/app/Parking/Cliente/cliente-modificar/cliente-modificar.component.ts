import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ClienteService } from 'src/app/services/cliente.service';
import { Cliente } from '../../models/cliente';

@Component({
  selector: 'app-cliente-modificar',
  templateUrl: './cliente-modificar.component.html',
  styleUrls: ['./cliente-modificar.component.css']
})
export class ClienteModificarComponent implements OnInit {

  cliente: Cliente;
  constructor(private clienteService: ClienteService, private rutaActiva: ActivatedRoute) { }

  ngOnInit() {
    this.cliente = new Cliente();
    const id = this.rutaActiva.snapshot.params.identificacion;
    this.clienteService.getId(id).subscribe(p => {
      this.cliente = p;
      this.cliente != null ? alert('Se Consulta la Cliente') : alert('Error al Consultar');
    });
   
  }

  update() {
    this.clienteService.put(this.cliente).subscribe(p => {
      alert(p);
    });
  }
}
