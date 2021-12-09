import { Component, OnInit } from '@angular/core';
import { Estacionamiento } from '../Parking/models/estacionamiento';
import { EstacionamientoService } from '../services/estacionamiento.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  estacionamientos: Estacionamiento[];
  constructor(private estacionamientoService: EstacionamientoService) { }
  ngOnInit() {
    this.estacionamientoService.get().subscribe(result => {
      this.estacionamientos = result;
    });
  }
}
