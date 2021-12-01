using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Persona
    {
        [Key]
        [Column(TypeName = "varchar(13)")]
        public string Cedula { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string Apellido { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Sexo { get; set; }

        [Column(TypeName = "int")]
        public int Edad { get; set; }

        [Column(TypeName = "varchar(13)")]
        public string Telefono { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string Email { get; set; }
    }
}
