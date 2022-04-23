using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Entities
{
    [Table("comanda")]
    [Index("IdCamarero", Name = "fk_camarerocomanda")]
    [Index("IdCocinero", Name = "fk_cocinerocomanda")]
    [Index("IdPedido", Name = "fk_pedidocomanda")]
    [Index("IdProducto", Name = "fk_productocomanda")]
    public partial class Comanda
    {
        [Key]
        [Column("id", TypeName = "int(50)")]
        public int Id { get; set; }
        [Column("id_camarero", TypeName = "int(50)")]
        public int IdCamarero { get; set; }
        [Column("id_cocinero", TypeName = "int(50)")]
        public int? IdCocinero { get; set; }
        [Column("id_producto", TypeName = "int(50)")]
        public int IdProducto { get; set; }
        [Column("id_pedido", TypeName = "int(50)")]
        public int IdPedido { get; set; }
        [Column("descripcion")]
        [StringLength(50)]
        public string? Descripcion { get; set; }
        [Column("estado", TypeName = "enum('Pendiente','En Preparación','Preparado','Entregado')")]
        public string? Estado { get; set; }

        [ForeignKey("IdCamarero")]
        [InverseProperty("Comanda")]
        public virtual Camarero IdCamareroNavigation { get; set; } = null!;
        [ForeignKey("IdCocinero")]
        [InverseProperty("Comanda")]
        public virtual Cocinero? IdCocineroNavigation { get; set; }
        [ForeignKey("IdPedido")]
        [InverseProperty("Comanda")]
        public virtual Pedido IdPedidoNavigation { get; set; } = null!;
        [ForeignKey("IdProducto")]
        [InverseProperty("Comanda")]
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
