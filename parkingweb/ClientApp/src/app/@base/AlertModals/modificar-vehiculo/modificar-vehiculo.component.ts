import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-modificar-vehiculo',
  templateUrl: './modificar-vehiculo.component.html',
  styleUrls: ['./modificar-vehiculo.component.css']
})
export class ModificarVehiculoComponent implements OnInit {

  @Input() title
  @Input() cuerpo
  @Input() cuerpo2
  @Input() idVehiculo
  @Input() marca
  @Input() tipo
  
  constructor(public modal: NgbActiveModal) { }

  ngOnInit(): void { }

}
