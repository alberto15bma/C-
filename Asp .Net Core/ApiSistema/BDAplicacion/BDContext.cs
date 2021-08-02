using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDAplicacion
{
    public partial class BDContext : DbContext
    {
        static BDContext()
        {
            Database.SetInitializer<BDContext>(null);
        }
        public BDContext()
            : base("Modelo")
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public static BDContext Create()
        {
            return new BDContext();
        }
        
    }
}
