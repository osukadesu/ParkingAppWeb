import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EstacionamientoService } from 'src/app/services/estacionamiento.service';
import { Estacionamiento } from '../../models/estacionamiento';

@Component({
  selector: 'app-estacionamiento-modificar',
  templateUrl: './estacionamiento-modificar.component.html',
  styleUrls: ['./estacionamiento-modificar.component.css']
})
export class EstacionamientoModificarComponent implements OnInit {

  estacionamiento: Estacionamiento;
  constructor(private estacionamientoService: EstacionamientoService, private rutaActiva: ActivatedRoute) { }

  ngOnInit() {
    this.estacionamiento = new Estacionamiento();
    const id = this.rutaActiva.snapshot.params.identificacion;
    this.estacionamientoService.getId(id).subscribe(p => {
      this.estacionamiento = p;
      this.estacionamiento != null ? alert('Se Consulta la Estacionamiento') : alert('Error al Consultar');
    });
   
  }

  update() {
    this.estacionamientoService.put(this.estacionamiento).subscribe(p => {
      alert(p);
    });
  }
}
