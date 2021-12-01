import { Pipe, PipeTransform } from '@angular/core';
import { Ticket } from '../Parking/models/ticket';

@Pipe({
  name: 'filtroTicket'
})
export class FiltroTicketPipe implements PipeTransform {

  transform(ticket: Ticket[], searchText: string): any {
    if (searchText == null) return ticket;
    return ticket.filter(p =>
      p.id_ticket.toLowerCase()
        .indexOf(searchText.toLowerCase()) !== -1);
  }

}
