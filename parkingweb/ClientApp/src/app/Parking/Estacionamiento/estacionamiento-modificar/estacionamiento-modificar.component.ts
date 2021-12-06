import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EstacionamientoService } from 'src/app/services/estacionamiento.service';
import { Estacionamiento } from '../../models/estacionamiento';

@Component({
  selector: 'app-estacionamiento-modificar',
  templateUrl: './estacionamiento-modificar.component.html',
  styleUrls: ['./estacionamiento-modificar.component.css']
})
export class EstacionamientoModificarComponent implements OnInit {

  estacionamiento: Estacionamiento;
  constructor(private estacionamientoService: EstacionamientoService, private rutaActiva: ActivatedRoute, private modalService: NgbModal) { }

  ngOnInit() {
    this.estacionamiento = new Estacionamiento();
    const id = this.rutaActiva.snapshot.params.identificacion;
    this.estacionamientoService.getId(id).subscribe(p => {
      this.estacionamiento = p;
      if (p != null) {
        const messageBox = this.modalService.open(EstacionamientoModificarComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: puede actualizar la información del estacionamiento';
        messageBox.componentInstance.cuerpo2 = 'Datos del estacionamiento:';
        messageBox.componentInstance.idEstacionamiento = 'Id estacionamiento: '+this.estacionamiento.idEstacionamiento;
        messageBox.componentInstance.tipo = 'Tipo de estacionamiento: '+this.estacionamiento.tipo;

      }
      else {
        const messageBox = this.modalService.open(EstacionamientoModificarComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: Error al consultar el estacionamiento: '+this.estacionamiento.idEstacionamiento;
      }
    });
   
  }

  update() {
    this.estacionamientoService.put(this.estacionamiento).subscribe(p => {
      alert(p);
    });
  }
}
