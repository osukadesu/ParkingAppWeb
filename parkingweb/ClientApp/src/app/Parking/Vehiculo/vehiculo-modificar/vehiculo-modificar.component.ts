import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
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
  constructor(private vehiculoService: VehiculoService, private clienteService:ClienteService, private rutaActiva: ActivatedRoute, private modalService: NgbModal) { }

  ngOnInit() {
    
    this.ConsultarClientes();
    this.vehiculo = new Vehiculo();
    const id = this.rutaActiva.snapshot.params.identificacion;
    this.vehiculoService.getId(id).subscribe(p => {
      this.vehiculo = p;
      
      if (p != null) {
        const messageBox = this.modalService.open(VehiculoModificarComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: puede actualizar los datos del vehiculo';
        messageBox.componentInstance.cuerpo2 = 'Datos del vehiculo:';
        messageBox.componentInstance.idVehiculo = 'Id vehiculo: '+this.vehiculo.idVehiculo;
        messageBox.componentInstance.marca = 'Marca: '+this.vehiculo.marca;
        messageBox.componentInstance.tipo = 'Tipo de vehiculo: '+this.vehiculo.tipo;

      }
      else {
        const messageBox = this.modalService.open(VehiculoModificarComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: Error al consultar el vehiculo: '+this.vehiculo.idVehiculo;
      }

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
