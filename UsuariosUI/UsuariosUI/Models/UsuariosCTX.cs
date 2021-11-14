using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuariosUI.Models
{
    public class UsuariosCTX : DbContext
    {
        public UsuariosCTX(DbContextOptions<UsuariosCTX> options) : base(options) { }
        
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
