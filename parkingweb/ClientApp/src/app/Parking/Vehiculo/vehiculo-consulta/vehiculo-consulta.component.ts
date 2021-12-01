import { Component, OnInit } from '@angular/core';
import { VehiculoService } from 'src/app/services/vehiculo.service';
import { Vehiculo } from '../../models/vehiculo';

@Component({
  selector: 'app-vehiculo-consulta',
  templateUrl: './vehiculo-consulta.component.html',
  styleUrls: ['./vehiculo-consulta.component.css']
})
export class VehiculoConsultaComponent implements OnInit {

  vehiculos: Vehiculo[];
  searchText: string;
  constructor(private vehiculoService: VehiculoService) { }
  ngOnInit() {
    this.vehiculoService.get().subscribe(result => {
      this.vehiculos = result;
    });
  }

}
