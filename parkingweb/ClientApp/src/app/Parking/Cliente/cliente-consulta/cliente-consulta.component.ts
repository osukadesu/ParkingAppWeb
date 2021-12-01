import { Component, OnInit } from '@angular/core';
import { ClienteService } from 'src/app/services/cliente.service';
import { Cliente } from '../../models/cliente';

@Component({
  selector: 'app-cliente-consulta',
  templateUrl: './cliente-consulta.component.html',
  styleUrls: ['./cliente-consulta.component.css']
})
export class ClienteConsultaComponent implements OnInit {

  clientes: Cliente[];
  searchText: string;
  constructor(private personaService: ClienteService) { }
  ngOnInit() {
    this.personaService.get().subscribe(result => {
      this.clientes = result;
    });
  }

}
