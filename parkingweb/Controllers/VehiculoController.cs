using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VehiculoModel;

[Route("api/[controller]")]
[ApiController]
public class VehiculoController : ControllerBase
{
    private readonly VehiculoService _vehiculoService;

    public IConfiguration Configuration { get; }

    public VehiculoController(ParkingContext context)
    {
        _vehiculoService = new VehiculoService(context);
    }

    // GET: api/Persona​
    [HttpGet]
    public ActionResult<VehiculoViewModel> Gets()
    {
        var response = _vehiculoService.ConsultarTodos();
        if (response.Error)
        {
            ModelState
                .AddModelError("Error al consultar vehiculo", response.Mensaje);
            var detallesproblemas = new ValidationProblemDetails(ModelState);
            detallesproblemas.Status = StatusCodes.Status500InternalServerError;
            return BadRequest(detallesproblemas);
        }
        else
        {
            return Ok(response.Vehiculos.Select(p => new VehiculoViewModel(p)));
        }
    }

    // GET: api/Persona/5​
    [HttpGet("{idvehiculo}")]
    public ActionResult<VehiculoViewModel> Get(string idvehiculo)
    {
        var vehiculo = _vehiculoService.BuscarxIdentificacion(idvehiculo);
        if (vehiculo == null) return NotFound();
        var vehiculoViewModel = new VehiculoViewModel(vehiculo);
        return vehiculoViewModel;
    }

    // POST: api/Persona​
    [HttpPost]
    public ActionResult<VehiculoViewModel> Post(VehiculoInputModel vehiculoInput)
    {
        Vehiculo vehiculo = MapearVehiculo(vehiculoInput);
        var response = _vehiculoService.Guardar(vehiculo);
        if (response.Error)
        {
            ModelState
                .AddModelError("Error al guardar vehiculo", response.Mensaje);
            var detallesproblemas = new ValidationProblemDetails(ModelState);
            detallesproblemas.Status = StatusCodes.Status500InternalServerError;
            return BadRequest(detallesproblemas);
        }
        return Ok(response.Vehiculo);
    }

    // DELETE: api/Persona/5​
    [HttpDelete("{idvehiculo}")]
    public ActionResult<string> Delete(string idvehiculo)
    {
        string mensaje = _vehiculoService.Eliminar(idvehiculo);
        return Ok(mensaje);
    }

    private Vehiculo MapearVehiculo(VehiculoInputModel vehiculoInput)
    {
        var vehiculo =
            new Vehiculo {
            IdVehiculo = vehiculoInput.IdVehiculo,
            Cedula = vehiculoInput.Cedula,
            Tipo = vehiculoInput.Tipo,
            Color = vehiculoInput.Color,
            Marca = vehiculoInput.Marca,
            Precio = vehiculoInput.Precio
            };
        return vehiculo;
    }
}