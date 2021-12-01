using System;
using Entidad;

namespace TicketModel
{
    public class TicketInputModel
    {
        public string IdTicket { get; set; }
        public string Cedula { get; set; }
        public string IdVehiculo { get; set; }
        public string IdEstacionamiento { get; set; }
        public DateTime FechaElaboracion { get; set; }
        public DateTime FechaSalida { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public int Dias { get; set; }
    }

    public class TicketViewModel : TicketInputModel
    {
        public TicketViewModel(Ticket ticket)
        {
            IdTicket = ticket.IdTicket;
            Cedula = ticket.Cedula;
            IdVehiculo = ticket.IdVehiculo;
            IdEstacionamiento = ticket.IdEstacionamiento;
            FechaElaboracion = ticket.FechaElaboracion;
            FechaSalida = ticket.FechaSalida;
            Iva = ticket.Iva;
            Total = ticket.Total;
            SubTotal = ticket.SubTotal;
            Dias= ticket.Dias;
        }
    }
}