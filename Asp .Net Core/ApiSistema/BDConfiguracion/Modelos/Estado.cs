using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDConfiguracion.Modelos
{
    [Table("Estado")]
    public class Estado
    {
        [Key]
        public int Id { get; set; }
        [StringLength(15)]
        public string Descripcion { get; set; }
    }
}
