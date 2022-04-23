using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Entities
{
    [Table("usuario")]
    [Index("Username", Name = "username", IsUnique = true)]
    public partial class Usuario
    {
        [Key]
        [Column("id", TypeName = "int(50)")]
        public int Id { get; set; }
        [Column("nombre")]
        [StringLength(50)]
        public string? Nombre { get; set; }
        [Column("apellidos")]
        [StringLength(100)]
        public string? Apellidos { get; set; }
        [Column("NSS")]
        [StringLength(20)]
        public string? Nss { get; set; }
        [Column("username")]
        [StringLength(50)]
        public string Username { get; set; } = null!;
        [Column("password")]
        [StringLength(200)]
        public string Password { get; set; } = null!;

        [InverseProperty("IdNavigation")]
        public virtual Camarero Camarero { get; set; } = null!;
        [InverseProperty("IdNavigation")]
        public virtual Cocinero Cocinero { get; set; } = null!;
        [InverseProperty("IdNavigation")]
        public virtual Gerente Gerente { get; set; } = null!;
    }
}
