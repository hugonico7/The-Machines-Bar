using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Entities
{
    [Table("camarero")]
    public partial class Camarero
    {
        public Camarero()
        {
            Comanda = new HashSet<Comanda>();
        }

        [Key]
        [Column("id", TypeName = "int(50)")]
        public int Id { get; set; }

        [ForeignKey("Id")]
        [InverseProperty("Camarero")]
        public virtual Usuario IdNavigation { get; set; } = null!;
        [InverseProperty("IdCamareroNavigation")]
        public virtual ICollection<Comanda> Comanda { get; set; }
    }
}
