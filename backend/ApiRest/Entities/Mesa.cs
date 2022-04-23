using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Entities
{
    [Table("mesa")]
    public partial class Mesa
    {
        public Mesa()
        {
            Pedidos = new HashSet<Pedido>();
            IdReservas = new HashSet<Reserva>();
        }

        [Key]
        [Column("id", TypeName = "int(50)")]
        public int Id { get; set; }
        [Column("estado", TypeName = "enum('Libre','Reservada','Ocupada')")]
        public string Estado { get; set; } = null!;

        [InverseProperty("IdMesaNavigation")]
        public virtual ICollection<Pedido> Pedidos { get; set; }

        [ForeignKey("IdMesa")]
        [InverseProperty("IdMesas")]
        public virtual ICollection<Reserva> IdReservas { get; set; }
    }
}
