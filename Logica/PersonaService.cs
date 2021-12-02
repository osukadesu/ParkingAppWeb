using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Logica
{
    public class PersonaService
    {
        private readonly ParkingContext _context;

        public PersonaService(ParkingContext context)
        {
            _context = context;
        }
        public GuardarPersonaResponse Guardar(Persona persona)
        {
            try
            {
                _context.Personas.Add(persona);
                _context.SaveChanges();
                return new GuardarPersonaResponse(persona);
            }
            catch (Exception e)

            {
                return new GuardarPersonaResponse($"Error de la Aplicacion: {e.Message}");
            }

        }
        public ConsultaPersonaResponse ConsultarTodos()
        {
            try
            {
                List<Persona> personas = _context.Personas.ToList();
                return new ConsultaPersonaResponse(personas);
            }
            catch (Exception e)
            {
                return new ConsultaPersonaResponse($"Error en la aplicacion:  {e.Message}");
            }
        }

        public Persona BuscarxIdentificacion(string cedula)
        {
            Persona persona = _context.Personas.Find(cedula);
            return persona;
        }
        
         public string Actualizar(Persona personaNuevo)
        {
            try
            {
                var personaViejo = _context.Personas.Find(personaNuevo.Cedula);
                if (personaViejo != null)
                {
                    personaViejo.Nombre = personaNuevo.Nombre;
                    personaViejo.Apellido = personaNuevo.Apellido;
                    personaViejo.Edad = personaNuevo.Edad;
                    personaViejo.Email = personaNuevo.Email;
                    personaViejo.Telefono = personaNuevo.Telefono;
                    personaViejo.Sexo = personaNuevo.Sexo;
                    _context.Personas.Update(personaViejo);
                    _context.SaveChanges();
                    return ($"El registro {personaNuevo.Nombre} se ha modificado");
                }
                else
                {
                    return $"Lo sentimos, {personaNuevo.Cedula} no se encuentra registrado";
                }
                
            }
            catch (Exception e)
            {
                return $"Error inesperado al Modificar: {e.Message}";
            }
            
        }

        public class ConsultaPersonaResponse
        {

            public ConsultaPersonaResponse(List<Persona> personas)
            {
                Error = false;
                Personas = personas;
            }

            public ConsultaPersonaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public Boolean Error { get; set; }
            public string Mensaje { get; set; }
            public List<Persona> Personas { get; set; }
        }
        public class GuardarPersonaResponse

        {

            public GuardarPersonaResponse(Persona persona)

            {
                Error = false;

                Persona = persona;

            }



            public GuardarPersonaResponse(string mensaje)

            {
                Error = true;
                Mensaje = mensaje;
            }

            public bool Error { get; set; }

            public string Mensaje { get; set; }

            public Persona Persona { get; set; }

        }
    }
}