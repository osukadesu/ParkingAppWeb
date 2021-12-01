import { Component, OnInit } from '@angular/core';
import { EstacionamientoService } from 'src/app/services/estacionamiento.service';
import { Estacionamiento } from '../../models/estacionamiento';

@Component({
  selector: 'app-estacionamiento-consulta',
  templateUrl: './estacionamiento-consulta.component.html',
  styleUrls: ['./estacionamiento-consulta.component.css']
})
export class EstacionamientoConsultaComponent implements OnInit {

  estacionamientos: Estacionamiento[];
  searchText: string;
  constructor(private estacionamientoService: EstacionamientoService) { }
  ngOnInit() {
    this.estacionamientoService.get().subscribe(result => {
      this.estacionamientos = result;
    });
  }

}
