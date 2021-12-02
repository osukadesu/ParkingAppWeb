import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ClienteService } from 'src/app/services/cliente.service';
import { VehiculoService } from 'src/app/services/vehiculo.service';
import { Cliente } from '../../models/cliente';
import { Vehiculo } from '../../models/vehiculo';

@Component({
  selector: 'app-vehiculo-modificar',
  templateUrl: './vehiculo-modificar.component.html',
  styleUrls: ['./vehiculo-modificar.component.css']
})
export class VehiculoModificarComponent implements OnInit {

  vehiculo: Vehiculo;
  clientes: Cliente[]=[];
  constructor(private vehiculoService: VehiculoService, private clienteService:ClienteService, private rutaActiva: ActivatedRoute) { }

  ngOnInit() {
    
    this.ConsultarClientes();
    this.vehiculo = new Vehiculo();
    const id = this.rutaActiva.snapshot.params.identificacion;
    this.vehiculoService.getId(id).subscribe(p => {
      this.vehiculo = p;
      this.vehiculo != null ? alert('Se Consulta la Vehiculo') : alert('Error al Consultar');
    });
   
  }
  ConsultarClientes()
  {
    this.clienteService.get().subscribe(result => {
          this.clientes = result;
        });
  }
  update() {
    this.vehiculoService.put(this.vehiculo).subscribe(p => {
      alert(p);
    });
  }
}
