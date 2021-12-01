using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Logica
{
    public class VehiculoService
    {
         private readonly ParkingContext _context;

        public VehiculoService(ParkingContext context)
        {
            _context = context;
        }
        public GuardarVehiculoResponse Guardar(Vehiculo vehiculo)
        {
            try
            {
                _context.Vehiculos.Add(vehiculo);
                _context.SaveChanges();
                return new GuardarVehiculoResponse(vehiculo);
            }
            catch (Exception e)

            {
                return new GuardarVehiculoResponse($"Error de la Aplicacion: {e.Message}");
            }

        }
        public ConsultaVehiculoResponse ConsultarTodos()
        {
            try
            {
                List<Vehiculo> vehiculos = _context.Vehiculos.ToList();
                return new ConsultaVehiculoResponse(vehiculos);
            }
            catch (Exception e)
            {
                return new ConsultaVehiculoResponse($"Error en la aplicacion:  {e.Message}");
            }
        }

        public Vehiculo BuscarxIdentificacion(string idvehiculo)
        {
            Vehiculo vehiculo = _context.Vehiculos.Find(idvehiculo);
            return vehiculo;
        }

        public string Eliminar(string idvehiculo)
        {
            Vehiculo vehiculo = new Vehiculo();
            if ((vehiculo = _context.Vehiculos.Find(idvehiculo)) != null)
            {
                _context.Vehiculos.Remove(vehiculo);
                _context.SaveChanges();
                return $"Se ha eliminado el vehiculo.";
            }
            else
            {
                return $"No se encontro el vehiculo. ";
            }
        }

        public class ConsultaVehiculoResponse
        {

            public ConsultaVehiculoResponse(List<Vehiculo> vehiculos)
            {
                Error = false;
                Vehiculos = vehiculos;
            }

            public ConsultaVehiculoResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public Boolean Error { get; set; }
            public string Mensaje { get; set; }
            public List<Vehiculo> Vehiculos { get; set; }
        }
        public class GuardarVehiculoResponse

        {

            public GuardarVehiculoResponse(Vehiculo vehiculo)

            {
                Error = false;

                Vehiculo = vehiculo;

            }



            public GuardarVehiculoResponse(string mensaje)

            {
                Error = true;
                Mensaje = mensaje;
            }

            public bool Error { get; set; }

            public string Mensaje { get; set; }

            public Vehiculo Vehiculo { get; set; }

        }
    }
}
