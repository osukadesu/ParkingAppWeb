import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Ticket } from '../Parking/models/ticket';

@Injectable({
  providedIn: 'root'
})
export class TicketService {
  baseUrl: string
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService,
  ) {
    this.baseUrl = baseUrl
  }
  get(): Observable<Ticket[]> {
    return this.http.get<Ticket[]>(this.baseUrl + 'api/Ticket').pipe(
      tap((_) => this.handleErrorService.log('datos enviados')),
      catchError(
        this.handleErrorService.handleError<Ticket[]>(
          'Consulta Ticket',
          null,
        ),
      ),
    )
  }
  post(ticket: Ticket): Observable<Ticket> {
    return this.http.post<Ticket>(this.baseUrl + 'api/Ticket', Ticket).pipe(
      tap((_) => this.handleErrorService.log('datos enviados')),
      catchError(
        this.handleErrorService.handleError<Ticket>('Registrar Ticket', null),
      ),
    )
  }
}
