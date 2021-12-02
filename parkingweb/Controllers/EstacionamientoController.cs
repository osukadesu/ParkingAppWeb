using Microsoft.AspNetCore.Mvc;
using Logica;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using Entidad;
using Datos;
using EstacionamientoModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class EstacionamientoController : ControllerBase
{
     private readonly EstacionamientoService _estacionamientoService;

    public IConfiguration Configuration { get; }

    public EstacionamientoController(ParkingContext context)
    {
        _estacionamientoService = new EstacionamientoService(context);
    }

    // GET: api/Estacionamiento
    [HttpGet]
    public ActionResult<EstacionamientoViewModel> Gets()
    {
        var response = _estacionamientoService.ConsultarTodos();
        if (response.Error)
        {
            ModelState
                .AddModelError("Error al consultar estacionamiento", response.Mensaje);
            var detallesproblemas = new ValidationProblemDetails(ModelState);
            detallesproblemas.Status = StatusCodes.Status500InternalServerError;
            return BadRequest(detallesproblemas);
        }
        else
        {
            return Ok(response.Estacionamientos.Select(p => new EstacionamientoViewModel(p)));
        }
    }

    // GET: api/Estacionamiento/5​
    [HttpGet("{idEstacionamiento}")]
    public ActionResult<EstacionamientoViewModel> Get(string idEstacionamiento)
    {
        var estacionamiento = _estacionamientoService.BuscarxIdentificacion(idEstacionamiento);
        if (estacionamiento == null) return NotFound();
        var estacionamientoViewModel = new EstacionamientoViewModel(estacionamiento);
        return estacionamientoViewModel;
    }

    // POST: api/Estacionamiento
    [HttpPost]
    public ActionResult<EstacionamientoViewModel> Post(EstacionamientoInputModel estacionamientoInput)
    {
        Estacionamiento estacionamiento = MapearEstacionamiento(estacionamientoInput);
        var response = _estacionamientoService.Guardar(estacionamiento);
        if (response.Error)
        {
            ModelState
                .AddModelError("Error al guardar estacionamiento", response.Mensaje);
            var detallesproblemas = new ValidationProblemDetails(ModelState);
            detallesproblemas.Status = StatusCodes.Status500InternalServerError;
            return BadRequest(detallesproblemas);
        }
        return Ok(response.Estacionamiento);
    }
    
    private Estacionamiento MapearEstacionamiento(EstacionamientoInputModel estacionamientoInput)
    {
        var estacionamiento =
            new Estacionamiento {
                IdEstacionamiento = estacionamientoInput.IdEstacionamiento,
                Tipo = estacionamientoInput.Tipo,
                Estado = estacionamientoInput.Estado,
                NumeroCupo = estacionamientoInput.NumeroCupo,
            };
        return estacionamiento;
    }

     // PUT: api/Estacionamiento/5
        [HttpPut("{idEstacionamiento}")]
        public ActionResult<string> Put(string idEstacionamiento, Estacionamiento estacionamiento)
        {
            var id=_estacionamientoService.BuscarxIdentificacion(estacionamiento.IdEstacionamiento);
            if(id==null){
                return BadRequest("No encontrado");
            }
            var mensaje=_estacionamientoService.Actualizar(estacionamiento);
           return Ok(mensaje) ;

        }
}