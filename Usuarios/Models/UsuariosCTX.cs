using Microsoft.EntityframeworkCore;
namespace Usuarios.Models {
    public class UsuariosCTX : DbContext{
        public UsuariosCTX(DbContextOptions<UsuariosCTX> options) : base(options){

        }

        public DBSet<Usuarios> Usuarios { get; set; }
    }    
}