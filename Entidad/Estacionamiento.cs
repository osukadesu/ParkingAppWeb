using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entidad
{
    public class Estacionamiento
    {
        [Key]
        [Column(TypeName = "varchar(4)")]
        public string IdEstacionamiento { get; set; }

        [Column(TypeName = "varchar(8)")]
        public string Tipo { get; set; }

        [Column(TypeName = "varchar(13)")]
        public string Estado { get; set; }

        [Column(TypeName = "int")]
        public int NumeroCupo { get; set; }
    }
}
