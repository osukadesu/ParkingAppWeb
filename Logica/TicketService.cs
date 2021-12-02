using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Logica
{
    public class TicketService
    {
       private readonly ParkingContext _context;

        public TicketService(ParkingContext context)
        {
            _context = context;
        }
        public GuardarTicketResponse Guardar(Ticket ticket)
        {
            try
            {
                _context.Tickets.Add(ticket);
                _context.SaveChanges();
                return new GuardarTicketResponse(ticket);
            }
            catch (Exception e)

            {
                return new GuardarTicketResponse($"Error de la Aplicacion: {e.Message}");
            }

        }
        public ConsultaTicketResponse ConsultarTodos()
        {
            try
            {
                List<Ticket> tickets = _context.Tickets.ToList();
                return new ConsultaTicketResponse(tickets);
            }
            catch (Exception e)
            {
                return new ConsultaTicketResponse($"Error en la aplicacion:  {e.Message}");
            }
        }

        public Ticket BuscarxIdentificacion(string idTicket)
        {
            Ticket ticket = _context.Tickets.Find(idTicket);
            return ticket;
        }

        public class ConsultaTicketResponse
        {

            public ConsultaTicketResponse(List<Ticket> tickets)
            {
                Error = false;
                Tickets = tickets;
            }

            public ConsultaTicketResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public Boolean Error { get; set; }
            public string Mensaje { get; set; }
            public List<Ticket> Tickets { get; set; }
        }
        public class GuardarTicketResponse

        {

            public GuardarTicketResponse(Ticket ticket)

            {
                Error = false;

                Ticket = ticket;

            }



            public GuardarTicketResponse(string mensaje)

            {
                Error = true;
                Mensaje = mensaje;
            }

            public bool Error { get; set; }

            public string Mensaje { get; set; }

            public Ticket Ticket { get; set; }

        }
    }
}
