import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Vehiculo } from '../Parking/models/vehiculo';

const httpOptionsPut = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  responseType: 'text'
};

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class VehiculoService {

  baseUrl: string;
  constructor(
      private http: HttpClient,
      @Inject('BASE_URL') baseUrl: string,
      private handleErrorService: HandleHttpErrorService)
  {
      this.baseUrl = baseUrl;
  }

  get(): Observable<Vehiculo[]> {
    return this.http.get<Vehiculo[]>(this.baseUrl + 'api/Vehiculo')
        .pipe(
            tap(_ => this.handleErrorService.log('datos enviados')),
            catchError(this.handleErrorService.handleError<Vehiculo[]>('Consulta Vehiculo', null))
        );
  }

  post(vehiculo: Vehiculo): Observable<Vehiculo> {
        return this.http.post<Vehiculo>(this.baseUrl + 'api/Vehiculo/' , vehiculo)
        .pipe(
            tap(_ => this.handleErrorService.log('datos enviados')),
            catchError(this.handleErrorService.handleError<Vehiculo>('Registrar Vehiculo', null))
        );
  }


  put(vehiculo: Vehiculo): Observable<any> {
    const url = `${this.baseUrl}api/vehiculo/${vehiculo.idVehiculo}`;
    return this.http.put(url, vehiculo, httpOptions)
    .pipe(
      tap(_ => this.handleErrorService.log('datos enviados')),
      catchError(this.handleErrorService.handleError<any>('Editar Vehiculo'))
    );
  }

  getId(id: string): Observable<Vehiculo> {
    const url = `${this.baseUrl + 'api/vehiculo'}/${id}`;
      return this.http.get<Vehiculo>(url, httpOptions)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Vehiculo>('Buscar Vehiculo', null))
      );
  }
}