using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Cliente : Persona
    {
        [Column(TypeName = "varchar(4)")]
        public string IdCliente { get; set; }

        [NotMapped]
        public IList<Ticket> Tickets { get; set; }

        [NotMapped]
        public IList<Vehiculo> Vehiculos { get; set; }
    }
}