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

        public Vehiculo BuscarxIdentificacion(string IdVehiculo)
        {
            Vehiculo vehiculo = _context.Vehiculos.Find(IdVehiculo);
            return vehiculo;
        }

        public string Actualizar(Vehiculo vehiculoNuevo)
        {
            try
            {
                var vehiculoViejo = _context.Vehiculos.Find(vehiculoNuevo.IdVehiculo);
                if (vehiculoViejo != null)
                {
                    vehiculoViejo.Cedula = vehiculoNuevo.Cedula;
                    vehiculoViejo.Tipo = vehiculoNuevo.Tipo;
                    vehiculoViejo.Color = vehiculoNuevo.Color;
                    vehiculoViejo.Marca = vehiculoNuevo.Marca;
                    vehiculoViejo.Precio = vehiculoNuevo.Precio;
                    _context.Vehiculos.Update(vehiculoViejo);
                    _context.SaveChanges();
                    return ($"El registro {vehiculoNuevo.IdVehiculo} se ha modificado");
                }
                else
                {
                    return $"Lo sentimos, {vehiculoNuevo.IdVehiculo} no se encuentra registrado";
                }
                
            }
            catch (Exception e)
            {
                return $"Error inesperado al Modificar: {e.Message}";
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
