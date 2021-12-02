using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Vehiculo
    {
        [Key]
        [Column(TypeName = "varchar(4)")]
        public string IdVehiculo { get; set; }

        [NotMapped]
        public Cliente Cliente { get; set; }

        [Column(TypeName = "varchar(13)")]
        public string Cedula { get; set; }

        [Column(TypeName = "varchar(8)")]
        public string Tipo { get; set; }

        [Column(TypeName = "varchar(8)")]
        public string Color { get; set; }

        [Column(TypeName = "varchar(8)")]
        public string Marca { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Precio { get; set; }
    }
}
