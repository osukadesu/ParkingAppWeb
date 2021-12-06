import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-modificar-estacionamiento',
  templateUrl: './modificar-estacionamiento.component.html',
  styleUrls: ['./modificar-estacionamiento.component.css']
})
export class ModificarEstacionamientoComponent implements OnInit {

  @Input() title
  @Input() cuerpo
  @Input() cuerpo2
  @Input() idEstacionamiento
  @Input() tipo
  
  constructor(public modal: NgbActiveModal) { }

  ngOnInit(): void { }

}
