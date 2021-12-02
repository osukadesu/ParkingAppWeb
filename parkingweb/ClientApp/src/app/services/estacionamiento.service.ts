import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Inject, Injectable } from '@angular/core'
import { Observable } from 'rxjs'
import { tap, catchError } from 'rxjs/operators'
import { HandleHttpErrorService } from '../@base/handle-http-error.service'
import { Estacionamiento } from '../Parking/models/estacionamiento'

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
export class EstacionamientoService {

  baseUrl: string;
  constructor(
      private http: HttpClient,
      @Inject('BASE_URL') baseUrl: string,
      private handleErrorService: HandleHttpErrorService)
  {
      this.baseUrl = baseUrl;
  }

  get(): Observable<Estacionamiento[]> {
    return this.http.get<Estacionamiento[]>(this.baseUrl + 'api/Estacionamiento')
        .pipe(
            tap(_ => this.handleErrorService.log('datos enviados')),
            catchError(this.handleErrorService.handleError<Estacionamiento[]>('Consulta Estacionamiento', null))
        );
  }

  post(estacionamiento: Estacionamiento): Observable<Estacionamiento> {
        return this.http.post<Estacionamiento>(this.baseUrl + 'api/Estacionamiento/' , estacionamiento)
        .pipe(
            tap(_ => this.handleErrorService.log('datos enviados')),
            catchError(this.handleErrorService.handleError<Estacionamiento>('Registrar Estacionamiento', null))
        );
  }


  put(estacionamiento: Estacionamiento): Observable<any> {
    const url = `${this.baseUrl}api/estacionamiento/${estacionamiento.idEstacionamiento}`;
    return this.http.put(url, estacionamiento, httpOptions)
    .pipe(
      tap(_ => this.handleErrorService.log('datos enviados')),
      catchError(this.handleErrorService.handleError<any>('Editar Estacionamiento'))
    );
  }

  getId(id: string): Observable<Estacionamiento> {
    const url = `${this.baseUrl + 'api/estacionamiento'}/${id}`;
      return this.http.get<Estacionamiento>(url, httpOptions)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Estacionamiento>('Buscar Estacionamiento', null))
      );
  }
}
