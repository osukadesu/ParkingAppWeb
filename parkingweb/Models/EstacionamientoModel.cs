using System;
using Entidad;

namespace EstacionamientoModel
{
    public class EstacionamientoInputModel
    {
        public string IdEstacionamiento { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public int NumeroCupo { get; set; }
    }

    public class EstacionamientoViewModel : EstacionamientoInputModel
    {
        public EstacionamientoViewModel(Estacionamiento estacionamiento)
        {
            IdEstacionamiento = estacionamiento.IdEstacionamiento;
            Tipo = estacionamiento.Tipo;
            Estado = estacionamiento.Estado;
            NumeroCupo = estacionamiento.NumeroCupo;
        }
    }
}