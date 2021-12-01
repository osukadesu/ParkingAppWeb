using System;
using Entidad;

namespace VehiculoModel
{
    public class VehiculoInputModel
    { 
        public string IdVehiculo { get; set; }
        public string Cedula { get; set; }
        public string Tipo { get; set; }
        public string Color { get; set; }
        public string Marca { get; set; }
        public int Precio { get; set; }
    }

    public class VehiculoViewModel : VehiculoInputModel
    {
        public VehiculoViewModel(Vehiculo vehiculo)
        {
            IdVehiculo = vehiculo.IdVehiculo;
            Cedula = vehiculo.Cedula;
            Tipo = vehiculo.Tipo;
            Color = vehiculo.Color;
            Marca = vehiculo.Marca;
            Precio = vehiculo.Precio;
        }
    }
}