import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ClienteConsultaComponent } from './Parking/Cliente/cliente-consulta/cliente-consulta.component';
import { ClienteRegistroComponent } from './Parking/Cliente/cliente-registro/cliente-registro.component';
import { VehiculoRegistroComponent } from './Parking/Vehiculo/vehiculo-registro/vehiculo-registro.component';
import { VehiculoConsultaComponent } from './Parking/Vehiculo/vehiculo-consulta/vehiculo-consulta.component';
import { EstacionamientoConsultaComponent } from './Parking/Estacionamiento/estacionamiento-consulta/estacionamiento-consulta.component';
import { EstacionamientoRegistroComponent } from './Parking/Estacionamiento/estacionamiento-registro/estacionamiento-registro.component';
import { TicketRegistroComponent } from './Parking/Ticket/ticket-registro/ticket-registro.component';
import { TicketConsultaComponent } from './Parking/Ticket/ticket-consulta/ticket-consulta.component';
import { AppRoutingModule } from './app-routing.module';
import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FiltroClientePipe } from './pipe/filtro-cliente.pipe';
import { FiltroTicketPipe } from './pipe/filtro-ticket.pipe';
import { FiltroVehiculoPipe } from './pipe/filtro-vehiculo.pipe';
import { FiltroEstacionamientoPipe } from './pipe/filtro-estacionamiento.pipe';
import { AlertModalComponent } from './@base/alert-modal/alert-modal.component';
import { ClienteModificarComponent } from './Parking/Cliente/cliente-modificar/cliente-modificar.component';
import { EstacionamientoModificarComponent } from './Parking/Estacionamiento/estacionamiento-modificar/estacionamiento-modificar.component';
import { VehiculoModificarComponent } from './Parking/Vehiculo/vehiculo-modificar/vehiculo-modificar.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ClienteConsultaComponent,
    ClienteRegistroComponent,
    VehiculoRegistroComponent,
    VehiculoConsultaComponent,
    EstacionamientoConsultaComponent,
    EstacionamientoRegistroComponent,
    TicketRegistroComponent,
    TicketConsultaComponent,
    FooterComponent,
    NavbarComponent,
    AlertModalComponent,
    FiltroClientePipe,
    FiltroTicketPipe,
    FiltroVehiculoPipe,
    FiltroEstacionamientoPipe,
    ClienteModificarComponent,
    EstacionamientoModificarComponent,
    VehiculoModificarComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    NgbModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ]),
    AppRoutingModule,
    NgbModule
  ],
  entryComponents:[AlertModalComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
