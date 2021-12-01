import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Estacionamiento } from '../Parking/models/estacionamiento';

@Injectable({
  providedIn: 'root'
})
export class EstacionamientoService {
  baseUrl: string
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService,
  ) {
    this.baseUrl = baseUrl
  }
  get(): Observable<Estacionamiento[]> {
    return this.http.get<Estacionamiento[]>(this.baseUrl + 'api/Estacionamiento').pipe(
      tap((_) => this.handleErrorService.log('datos enviados')),
      catchError(
        this.handleErrorService.handleError<Estacionamiento[]>(
          'Consulta Estacionamiento',
          null,
        ),
      ),
    )
  }
  post(estacionamiento: Estacionamiento): Observable<Estacionamiento> {
    return this.http.post<Estacionamiento>(this.baseUrl + 'api/Estacionamiento', estacionamiento).pipe(
      tap((_) => this.handleErrorService.log('datos enviados')),
      catchError(
        this.handleErrorService.handleError<Estacionamiento>('Registrar Estacionamiento', null),
      ),
    )
  }
}
