import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Vehiculo } from '../Parking/models/vehiculo';

@Injectable({
  providedIn: 'root'
})
export class VehiculoService {
  baseUrl: string
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService,
  ) {
    this.baseUrl = baseUrl
  }
  get(): Observable<Vehiculo[]> {
    return this.http.get<Vehiculo[]>(this.baseUrl + 'api/Vehiculo').pipe(
      tap((_) => this.handleErrorService.log('datos enviados')),
      catchError(
        this.handleErrorService.handleError<Vehiculo[]>(
          'Consulta Vehiculo',
          null,
        ),
      ),
    )
  }
  post(vehiculo: Vehiculo): Observable<Vehiculo> {
    return this.http.post<Vehiculo>(this.baseUrl + 'api/Vehiculo', Vehiculo).pipe(
      tap((_) => this.handleErrorService.log('datos enviados')),
      catchError(
        this.handleErrorService.handleError<Vehiculo>('Registrar Vehiculo', null),
      ),
    )
  }
}
