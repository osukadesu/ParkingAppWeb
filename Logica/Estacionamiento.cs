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

        public Estacionamiento BuscarxIdentificacion(string id_estacionamiento)
        {
            Estacionamiento estacionamiento = _context.Estacionamientos.Find(id_estacionamiento);
            return estacionamiento;
        }

        public string Actualizar(Estacionamiento estacionamientoNuevo)
        {
            try
            {
                var estacionamientoViejo = _context.Estacionamientos.Find(estacionamientoNuevo.IdEstacionamiento);
                if (estacionamientoViejo != null)
                {
                    estacionamientoViejo.NumeroCupo = estacionamientoNuevo.NumeroCupo;
                    _context.Estacionamientos.Update(estacionamientoViejo);
                    _context.SaveChanges();
                    return ($"El registro {estacionamientoNuevo.NumeroCupo} se ha modificado");
                }
                else
                {
                    return $"Lo sentimos, {estacionamientoNuevo.IdEstacionamiento} no se encuentra registrado";
                }
                
            }
            catch (Exception e)
            {
                return $"Error inesperado al Modificar: {e.Message}";
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
