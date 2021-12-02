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

    // GET: api/Vehiculo​
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

    // GET: api/Vehiculo/5​
    [HttpGet("{idVehiculo}")]
    public ActionResult<VehiculoViewModel> Get(string idVehiculo)
    {
        var vehiculo = _vehiculoService.BuscarxIdentificacion(idVehiculo);
        if (vehiculo == null) return NotFound();
        var vehiculoViewModel = new VehiculoViewModel(vehiculo);
        return vehiculoViewModel;
    }

    // POST: api/Vehiculo​
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
    
    private Vehiculo MapearVehiculo(VehiculoInputModel vehiculoInput)
    {
        var vehiculo =
            new Vehiculo {
                IdVehiculo = vehiculoInput.IdVehiculo,
                Cedula = vehiculoInput.Cedula,
                Tipo = vehiculoInput.Tipo,
                Color = vehiculoInput.Color,
                Marca = vehiculoInput.Marca,
                Precio = vehiculoInput.Precio,
               
            };
        return vehiculo;
    }

     // PUT: api/Vehiculo/5
        [HttpPut("{idVehiculo}")]
        public ActionResult<string> Put(string idVehiculo, Vehiculo vehiculo)
        {
            var id=_vehiculoService.BuscarxIdentificacion(vehiculo.IdVehiculo);
            if(id==null){
                return BadRequest("No encontrado");
            }
            var mensaje=_vehiculoService.Actualizar(vehiculo);
           return Ok(mensaje) ;

        }
}