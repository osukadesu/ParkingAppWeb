using Microsoft.AspNetCore.Mvc;
using Logica;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using Entidad;
using Datos;
using PersonaModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class PersonaController : ControllerBase
{
   private readonly PersonaService _personaService;

    public IConfiguration Configuration { get; }

    public PersonaController(ParkingContext context)
    {
        _personaService = new PersonaService(context);
    }

    // GET: api/Persona​
    [HttpGet]
    public ActionResult<PersonaViewModel> Gets()
    {
        var response = _personaService.ConsultarTodos();
        if (response.Error)
        {
            ModelState
                .AddModelError("Error al consultar persona", response.Mensaje);
            var detallesproblemas = new ValidationProblemDetails(ModelState);
            detallesproblemas.Status = StatusCodes.Status500InternalServerError;
            return BadRequest(detallesproblemas);
        }
        else
        {
            return Ok(response.Personas.Select(p => new PersonaViewModel(p)));
        }
    }

    // GET: api/Persona/5​
    [HttpGet("{cedula}")]
    public ActionResult<PersonaViewModel> Get(string cedula)
    {
        var persona = _personaService.BuscarxIdentificacion(cedula);
        if (persona == null) return NotFound();
        var personaViewModel = new PersonaViewModel(persona);
        return personaViewModel;
    }

    // POST: api/Persona
    [HttpPost]
    public ActionResult<PersonaViewModel> Post(PersonaInputModel personaInput)
    {
        Persona persona = MapearPersona(personaInput);
        var response = _personaService.Guardar(persona);
        if (response.Error)
        {
            ModelState
                .AddModelError("Error al guardar persona", response.Mensaje);
            var detallesproblemas = new ValidationProblemDetails(ModelState);
            detallesproblemas.Status = StatusCodes.Status500InternalServerError;
            return BadRequest(detallesproblemas);
        }
        return Ok(response.Persona);
    }
    
    private Persona MapearPersona(PersonaInputModel personaInput)
    {
        var persona =
            new Persona {
                Cedula = personaInput.Cedula,
                Nombre = personaInput.Nombre,
                Apellido =personaInput.Apellido,
                Edad = personaInput.Edad,
                Sexo = personaInput.Sexo,
                Email = personaInput.Email,
                Telefono = personaInput.Telefono,
            };
        return persona;
    }

     // PUT: api/Persona/5
        [HttpPut("{cedula}")]
        public ActionResult<string> Put(string cedula, Persona persona)
        {
            var id=_personaService.BuscarxIdentificacion(persona.Cedula);
            if(id==null){
                return BadRequest("No encontrado");
            }
            var mensaje=_personaService.Actualizar(persona);
           return Ok(mensaje) ;

        }
}