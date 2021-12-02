using System.Collections.Generic;
using System.Linq;
using ClienteModel;
using Datos;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly ClienteService _clienteService;

    public IConfiguration Configuration { get; }

    public ClienteController(ParkingContext context)
    {
        _clienteService = new ClienteService(context);
    }

    // GET: api/Cliente​
    [HttpGet]
    public ActionResult<ClienteViewModel> Gets()
    {
        var response = _clienteService.ConsultarTodos();
        if (response.Error)
        {
            ModelState
                .AddModelError("Error al consultar cliente", response.Mensaje);
            var detallesproblemas = new ValidationProblemDetails(ModelState);
            detallesproblemas.Status = StatusCodes.Status500InternalServerError;
            return BadRequest(detallesproblemas);
        }
        else
        {
            return Ok(response.Clientes.Select(p => new ClienteViewModel(p)));
        }
    }

    // GET: api/Cliente/5​
    [HttpGet("{idCliente}")]
    public ActionResult<ClienteViewModel> Get(string idCliente)
    {
        var cliente = _clienteService.BuscarxIdentificacion(idCliente);
        if (cliente == null) return NotFound();
        var clienteViewModel = new ClienteViewModel(cliente);
        return clienteViewModel;
    }

    // POST: api/Cliente​
    [HttpPost]
    public ActionResult<ClienteViewModel> Post(ClienteInputModel clienteInput)
    {
        Cliente cliente = MapearCliente(clienteInput);
        var response = _clienteService.Guardar(cliente);
        if (response.Error)
        {
            ModelState
                .AddModelError("Error al guardar cliente", response.Mensaje);
            var detallesproblemas = new ValidationProblemDetails(ModelState);
            detallesproblemas.Status = StatusCodes.Status500InternalServerError;
            return BadRequest(detallesproblemas);
        }
        return Ok(response.Cliente);
    }
    
    private Cliente MapearCliente(ClienteInputModel clienteInput)
    {
        var cliente =
            new Cliente {
                Cedula = clienteInput.Cedula,
                IdCliente = clienteInput.Cedula,
                Nombre = clienteInput.Nombre,
                Apellido =clienteInput.Apellido,
                Edad = clienteInput.Edad,
                Sexo = clienteInput.Sexo,
                Email = clienteInput.Email,
                Telefono = clienteInput.Telefono,
            };
        return cliente;
    }

     // PUT: api/Cliente/5
        [HttpPut("{idCliente}")]
        public ActionResult<string> Put(string idCliente, Cliente cliente)
        {
            var id=_clienteService.BuscarxIdentificacion(cliente.IdCliente);
            if(id==null){
                return BadRequest("No encontrado");
            }
            var mensaje=_clienteService.Actualizar(cliente);
           return Ok(mensaje) ;

        }
}