using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Entities
{
    [Table("gerente")]
    public partial class Gerente
    {
        [Key]
        [Column("id", TypeName = "int(50)")]
        public int Id { get; set; }

        [ForeignKey("Id")]
        [InverseProperty("Gerente")]
        public virtual Usuario IdNavigation { get; set; } = null!;
    }
}
