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

    // GET: api/Ticket​
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

    // GET: api/Ticket/5​
    [HttpGet("{idTicket}")]
    public ActionResult<TicketViewModel> Get(string idTicket)
    {
        var ticket = _ticketService.BuscarxIdentificacion(idTicket);
        if (ticket == null) return NotFound();
        var ticketViewModel = new TicketViewModel(ticket);
        return ticketViewModel;
    }

    // POST: api/Ticket​
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
    
    private Ticket MapearTicket(TicketInputModel ticketInput)
    {
        var ticket =
            new Ticket {
                IdTicket = ticketInput.IdTicket,
                Cedula= ticketInput.Cedula,
                IdVehiculo= ticketInput.IdVehiculo,
                IdEstacionamiento= ticketInput.IdEstacionamiento,
                FechaElaboracion= ticketInput.FechaElaboracion,
                FechaSalida= ticketInput.FechaSalida,
                Iva= ticketInput.Iva,
                Total= ticketInput.Total,
                SubTotal= ticketInput.SubTotal,
                Dias= ticketInput.Dias,
            };
        return ticket;
    }
}