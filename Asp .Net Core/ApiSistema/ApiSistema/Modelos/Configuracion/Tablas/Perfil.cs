using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSistema.Modelos.Configuracion.Tablas
{
    [Table("Perfil")]
    public class Perfil
    {
        [Key]
        public int Id { get; set; }
        [StringLength(60)]
        public string Descripcion { get; set; }
        public int EstadoId { get; set; }
        [ForeignKey("EstadoId")]
        public Estado estado { get; set; }
    }
}
