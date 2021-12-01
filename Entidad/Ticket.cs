using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Ticket
    {
        [Key]
        [Column(TypeName = "varchar(4)")]
        public string IdTicket { get; set; }

        [NotMapped]
        public Cliente Cliente { get; set; }

        [Column(TypeName = "varchar(13)")]
        public string Cedula { get; set; }

        [NotMapped]
        public Vehiculo Vehiculo { get; set; }

        [Column(TypeName = "varchar(4)")]
        public string IdVehiculo { get; set; }

        [NotMapped]
        public Estacionamiento Estacionamiento { get; set; }

        [Column(TypeName = "varchar(4)")]
        public string IdEstacionamiento { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime FechaElaboracion { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime FechaSalida { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Iva { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Total { get; set; }

        [Column(TypeName = "decimal")]
        public decimal SubTotal { get; set; }

        [Column(TypeName = "int")]
        public int Dias { get; set; }

        public void CalcularTotal(Vehiculo vehiculo)
        {
            Vehiculo = vehiculo;
            Iva = Vehiculo.Precio * 0.19m;
            Total = Vehiculo.Precio * Dias;
            SubTotal = Total / 1.19m;
        }
    }
}
