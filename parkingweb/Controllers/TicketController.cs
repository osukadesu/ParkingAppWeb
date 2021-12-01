using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TicketModel;

[Route("api/[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly TicketService _ticketService;

    public IConfiguration Configuration { get; }

    public TicketController(ParkingContext context)
    {
        _ticketService = new TicketService(context);
    }

    // GET: api/Persona​
    [HttpGet]
    public ActionResult<TicketViewModel> Gets()
    {
        var response = _ticketService.ConsultarTodos();
        if (response.Error)
        {
            ModelState
                .AddModelError("Error al consultar ticket", response.Mensaje);
            var detallesproblemas = new ValidationProblemDetails(ModelState);
            detallesproblemas.Status = StatusCodes.Status500InternalServerError;
            return BadRequest(detallesproblemas);
        }
        else
        {
            return Ok(response.Tickets.Select(p => new TicketViewModel(p)));
        }
    }

    // GET: api/Persona/5​
    [HttpGet("{idticket}")]
    public ActionResult<TicketViewModel> Get(string idticket)
    {
        var ticket = _ticketService.BuscarxIdentificacion(idticket);
        if (ticket == null) return NotFound();
        var ticketViewModel = new TicketViewModel(ticket);
        return ticketViewModel;
    }

    // POST: api/Persona​
    [HttpPost]
    public ActionResult<TicketViewModel> Post(TicketInputModel ticketInput)
    {
        Ticket ticket = MapearTicket(ticketInput);
        var response = _ticketService.Guardar(ticket);
        if (response.Error)
        {
            ModelState
                .AddModelError("Error al guardar ticket", response.Mensaje);
            var detallesproblemas = new ValidationProblemDetails(ModelState);
            detallesproblemas.Status = StatusCodes.Status500InternalServerError;
            return BadRequest(detallesproblemas);
        }
        return Ok(response.Ticket);
    }

    // DELETE: api/Persona/5​
    [HttpDelete("{idticket}")]
    public ActionResult<string> Delete(string idticket)
    {
        string mensaje = _ticketService.Eliminar(idticket);
        return Ok(mensaje);
    }

    private Ticket MapearTicket(TicketInputModel ticketInput)
    {
        var ticket =
            new Ticket {
            IdTicket = ticketInput.IdTicket,
            Cedula = ticketInput.Cedula,
            IdVehiculo = ticketInput.IdVehiculo,
            IdEstacionamiento = ticketInput.IdEstacionamiento,
            FechaElaboracion = ticketInput.FechaElaboracion,
            FechaSalida = ticketInput.FechaSalida,
            Iva = ticketInput.Iva,
            Total = ticketInput.Total,
            SubTotal = ticketInput.SubTotal,
            Dias= ticketInput.Dias,
            };
        return ticket;
    }
}