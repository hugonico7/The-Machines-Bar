using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Entities
{
    [Table("categoria")]
    public partial class Categoria
    {
        public Categoria(string nombre)
        {
            Nombre = nombre;
        }

        [Key]
        [Column("id", TypeName = "int(50)")]
        public int Id { get; set; }
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [InverseProperty("IdCatNavigation")]
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
