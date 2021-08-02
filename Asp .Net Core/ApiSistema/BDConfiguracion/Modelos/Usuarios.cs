using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDConfiguracion.Modelos
{
    [Table("Usuario")]
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        [StringLength(13)]
        public string Cedula { get; set; }
        [StringLength(100)]
        public string Apellidos { get; set; }
        [StringLength(100)]
        public string Nombres { get; set; }
        [StringLength(40)]
        [Required]
        public string Usuario { get; set; }
        [StringLength(30)]
        [Required]
        public string Password { get; set; }
        public int PasswordDias { get; set; }
        public DateTime PasswordFecha { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [ScaffoldColumn(true)]
        [UIHint("Image")]
        public byte[] Foto { get; set; }
        public bool Activo { get; set; }
        public bool Bloqueado { get; set; }
        public bool Notificacion { get; set; }
        public bool InicioSesion { get; set; }
        public int LoginIntentos { get; set; }
        public int PerfilId { get; set; }
        [ForeignKey("PerfilId")]
        public Perfil perfil { get; set; }
    }
}
