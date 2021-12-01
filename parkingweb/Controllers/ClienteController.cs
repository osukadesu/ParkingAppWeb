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

    // GET: api/Persona​
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

    // GET: api/Persona/5​
    [HttpGet("{idcliente}")]
    public ActionResult<ClienteViewModel> Get(string idcliente)
    {
        var cliente = _clienteService.BuscarxIdentificacion(idcliente);
        if (cliente == null) return NotFound();
        var clienteViewModel = new ClienteViewModel(cliente);
        return clienteViewModel;
    }

    // POST: api/Persona​
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

    // DELETE: api/Persona/5​
    /*[HttpDelete("{idcliente}")]
    public ActionResult<string> Delete(string idcliente)
    {
        string mensaje = _clienteService.Eliminar(idcliente);
        return Ok(mensaje);
    }
*/
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
}