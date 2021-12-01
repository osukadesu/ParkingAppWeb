using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Logica
{
    public class EstacionamientoService
    {
        private readonly ParkingContext _context;

        public EstacionamientoService(ParkingContext context)
        {
            _context = context;
        }
        public GuardarEstacionamientoResponse Guardar(Estacionamiento estacionamiento)
        {
            try
            {
                _context.Estacionamientos.Add(estacionamiento);
                _context.SaveChanges();
                return new GuardarEstacionamientoResponse(estacionamiento);
            }
            catch (Exception e)

            {
                return new GuardarEstacionamientoResponse($"Error de la Aplicacion: {e.Message}");
            }

        }
        public ConsultaEstacionamientoResponse ConsultarTodos()
        {
            try
            {
                List<Estacionamiento> estacionamientos = _context.Estacionamientos.ToList();
                return new ConsultaEstacionamientoResponse(estacionamientos);
            }
            catch (Exception e)
            {
                return new ConsultaEstacionamientoResponse($"Error en la aplicacion:  {e.Message}");
            }
        }

        public Estacionamiento BuscarxIdentificacion(string idestacionamiento)
        {
            Estacionamiento estacionamiento = _context.Estacionamientos.Find(idestacionamiento);
            return estacionamiento;
        }

        public string Eliminar(string idestacionamiento)
        {
            Estacionamiento estacionamiento = new Estacionamiento();
            if ((estacionamiento = _context.Estacionamientos.Find(idestacionamiento)) != null)
            {
                _context.Estacionamientos.Remove(estacionamiento);
                _context.SaveChanges();
                return $"Se ha eliminado el estacionamiento.";
            }
            else
            {
                return $"No se encontro el estacionamiento. ";
            }
        }

        public class ConsultaEstacionamientoResponse
        {

            public ConsultaEstacionamientoResponse(List<Estacionamiento> estacionamientos)
            {
                Error = false;
                Estacionamientos = estacionamientos;
            }

            public ConsultaEstacionamientoResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public Boolean Error { get; set; }
            public string Mensaje { get; set; }
            public List<Estacionamiento> Estacionamientos { get; set; }
        }
        public class GuardarEstacionamientoResponse

        {

            public GuardarEstacionamientoResponse(Estacionamiento estacionamiento)

            {
                Error = false;

                Estacionamiento = estacionamiento;

            }



            public GuardarEstacionamientoResponse(string mensaje)

            {
                Error = true;
                Mensaje = mensaje;
            }

            public bool Error { get; set; }

            public string Mensaje { get; set; }

            public Estacionamiento Estacionamiento { get; set; }

        }
    }
}
