﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Entities
{
    [Table("camarero")]
    public partial class Camarero : Usuario
    {
        public Camarero(String nombre, String apellidos, String nss, String username, String password)
            : base(nombre, apellidos, nss, username, password)
        {
            Comanda = new HashSet<Comanda>();
        }
        
        [InverseProperty("IdCamareroNavigation")]
        public virtual ICollection<Comanda> Comanda { get; set; }
    }
}