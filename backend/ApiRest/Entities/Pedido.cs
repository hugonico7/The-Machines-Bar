using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Entities
{
    [Table("pedido")]
    [Index("IdMesa", Name = "fk_idmesa")]
    public partial class Pedido
    {
        public Pedido()
        {
            Comanda = new HashSet<Comanda>();
        }

        [Key]
        [Column("id", TypeName = "int(50)")]
        public int Id { get; set; }
        [Column("fecha", TypeName = "datetime")]
        public DateTime? Fecha { get; set; }
        [Column("precio_total")]
        [Precision(5, 2)]
        public decimal PrecioTotal { get; set; }
        [Column("estado", TypeName = "enum('Pagado','Pendiente')")]
        public string? Estado { get; set; }
        [Column("id_mesa", TypeName = "int(50)")]
        public int IdMesa { get; set; }

        [ForeignKey("IdMesa")]
        [InverseProperty("Pedidos")]
        public virtual Mesa IdMesaNavigation { get; set; } = null!;
        [InverseProperty("IdPedidoNavigation")]
        public virtual ICollection<Comanda> Comanda { get; set; }
    }
}
