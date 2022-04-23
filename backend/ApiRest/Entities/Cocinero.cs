using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Entities
{
    [Table("cocinero")]
    public partial class Cocinero
    {
        public Cocinero()
        {
            Comanda = new HashSet<Comanda>();
        }

        [Key]
        [Column("id", TypeName = "int(50)")]
        public int Id { get; set; }

        [ForeignKey("Id")]
        [InverseProperty("Cocinero")]
        public virtual Usuario IdNavigation { get; set; } = null!;
        [InverseProperty("IdCocineroNavigation")]
        public virtual ICollection<Comanda> Comanda { get; set; }
    }
}
