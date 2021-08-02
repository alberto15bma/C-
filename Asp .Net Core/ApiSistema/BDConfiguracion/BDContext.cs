using BDConfiguracion.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDConfiguracion
{
    public partial class BDContext : DbContext
    {
        public BDContext()
            : base("Modelo")
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public static BDContext Create()
        {
            return new BDContext();
        }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
