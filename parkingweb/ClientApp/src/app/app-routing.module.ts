import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ClienteRegistroComponent } from './Parking/Cliente/cliente-registro/cliente-registro.component';
import { ClienteConsultaComponent } from './Parking/Cliente/cliente-consulta/cliente-consulta.component';
import { VehiculoRegistroComponent } from './Parking/Vehiculo/vehiculo-registro/vehiculo-registro.component';
import { VehiculoConsultaComponent } from './Parking/Vehiculo/vehiculo-consulta/vehiculo-consulta.component';
import { EstacionamientoRegistroComponent } from './Parking/Estacionamiento/estacionamiento-registro/estacionamiento-registro.component';
import { EstacionamientoConsultaComponent } from './Parking/Estacionamiento/estacionamiento-consulta/estacionamiento-consulta.component';
import { TicketRegistroComponent } from './Parking/Ticket/ticket-registro/ticket-registro.component';
import { TicketConsultaComponent } from './Parking/Ticket/ticket-consulta/ticket-consulta.component';
import { ClienteModificarComponent } from './Parking/Cliente/cliente-modificar/cliente-modificar.component';
import { EstacionamientoModificarComponent } from './Parking/Estacionamiento/estacionamiento-modificar/estacionamiento-modificar.component';
import { VehiculoModificarComponent } from './Parking/Vehiculo/vehiculo-modificar/vehiculo-modificar.component';


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'clienteregistrar', component: ClienteRegistroComponent },
  { path: 'clienteconsultar', component: ClienteConsultaComponent },
  { path: 'clientemodificar/:identificacion', component: ClienteModificarComponent },
  { path: 'vehiculoregistrar', component: VehiculoRegistroComponent },
  { path: 'vehiculomodificar/:identificacion', component: VehiculoModificarComponent },
  { path: 'vehiculoconsultar', component: VehiculoConsultaComponent },
  { path: 'estacionamientoregistrar', component: EstacionamientoRegistroComponent },
  { path: 'estacionamientomodificar/:identificacion', component: EstacionamientoModificarComponent },
  { path: 'estacionamientoconsultar', component: EstacionamientoConsultaComponent },
  { path: 'ticketregistrar', component: TicketRegistroComponent },
  { path: 'ticketconsultar', component: TicketConsultaComponent },
  { path: '', component: HomeComponent}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }