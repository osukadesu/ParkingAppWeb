import { Component, OnInit } from '@angular/core';
import { TicketService } from 'src/app/services/ticket.service';
import { Ticket } from '../../models/ticket';

@Component({
  selector: 'app-ticket-consulta',
  templateUrl: './ticket-consulta.component.html',
  styleUrls: ['./ticket-consulta.component.css']
})
export class TicketConsultaComponent implements OnInit {

  tickets: Ticket[];
  searchText: string;
  constructor(private ticketService: TicketService) { }
  ngOnInit() {
    this.ticketService.get().subscribe(result => {
      this.tickets = result;
    });
  }
}
