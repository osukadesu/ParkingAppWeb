using Microsoft.AspNetCore.Mvc;
using Logica;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using Entidad;
using Datos;
using EstacionamientoModel;
using Microsoft.AspNetCore.Authorization;

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
            return BadRequest(response.Mensaje);
        }
        else
        {
            return Ok(response.Estacionamientos.Select(p => new EstacionamientoViewModel(p)));
        }
    }
    // GET: api/Persona/5​
    [HttpGet("{id_estacionamiento}")]
    public ActionResult<EstacionamientoViewModel> Get(string id_estacionamiento)
    {
        var estacionamiento = _estacionamientoService.BuscarxIdentificacion(id_estacionamiento);
        if (estacionamiento == null) return NotFound();
        var estacionamientoViewModel = new EstacionamientoViewModel(estacionamiento);
        return estacionamientoViewModel;
    }

    // POST: api/Persona​

    [HttpPost]
    public ActionResult<EstacionamientoViewModel> Post(EstacionamientoInputModel estacionamientoInput)
    {
        Estacionamiento estacionamiento = MapearEstacionamiento(estacionamientoInput);
        var response = _estacionamientoService.Guardar(estacionamiento);
        if (response.Error)
        {
            return BadRequest(response.Mensaje);
        }
        return Ok(response.Estacionamiento);
    }

    // DELETE: api/Persona/5​

    [HttpDelete("{id_estacionamiento}")]
    public ActionResult<string> Delete(string id_estacionamiento)
    {
        string mensaje = _estacionamientoService.Eliminar(id_estacionamiento);
        return Ok(mensaje);
    }

    private Estacionamiento MapearEstacionamiento(EstacionamientoInputModel estacionamientoInput)
    {
        var estacionamiento = new Estacionamiento
        {
            IdEstacionamiento = estacionamientoInput.IdEstacionamiento, 
            Tipo = estacionamientoInput.Tipo,
            Estado =estacionamientoInput.Estado,
            NumeroCupo = estacionamientoInput.NumeroCupo,
        };
        return estacionamiento;
    }
}