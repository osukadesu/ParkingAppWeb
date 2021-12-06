import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-modificar-cliente',
  templateUrl: './modificar-cliente.component.html',
  styleUrls: ['./modificar-cliente.component.css']
})
export class ModificarClienteComponent implements OnInit {

  @Input() title
  @Input() cuerpo
  @Input() cuerpo2
  @Input() cedula
  @Input() nombre
  @Input() apellido
  constructor(public modal: NgbActiveModal) { }

  ngOnInit(): void { }


}
