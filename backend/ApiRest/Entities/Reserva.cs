using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Entities
{
    [Table("reserva")]
    public partial class Reserva
    {
        public Reserva()
        {
            IdMesas = new HashSet<Mesa>();
        }

        [Key]
        [Column("id", TypeName = "int(50)")]
        public int Id { get; set; }
        [Column("nombre_Cliente")]
        [StringLength(50)]
        public string NombreCliente { get; set; } = null!;
        [Column("telefono", TypeName = "int(50)")]
        public int Telefono { get; set; }
        [Column("cantidad_personas", TypeName = "int(50)")]
        public int CantidadPersonas { get; set; }
        [Column("hora_fecha", TypeName = "datetime")]
        public DateTime HoraFecha { get; set; }

        [ForeignKey("IdReserva")]
        [InverseProperty("IdReservas")]
        public virtual ICollection<Mesa> IdMesas { get; set; }
    }
}
