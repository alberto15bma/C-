using ApiSistema.Modelos.Configuracion.Tablas;
using ApiSistema.Sistema;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSistema.Logica
{
    public class ClsUsuario
    {
        public Usuarios GetLogin(Usuarios usuario)
        {
            Usuarios user = null;
            using (var db = new SqlConnection(BDConexion.Conexion(BDParametros.BDConfiguracion)))
            {
                try
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();

                    var p = new DynamicParameters();
                    p.Add("UsuarioLogin", usuario.Usuario, dbType: DbType.String);
                    p.Add("PasswordLogin", Utilidades.Encriptar(usuario.Password), dbType: DbType.String);

                    var sql = $"SP_AutenticarUsuario";
                    user = db.Query<Usuarios>(sql, p, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    
                    db.Close();
                }
                catch (Exception e)
                {
                    user = null;
                }
                finally
                {
                    ((IDisposable)db).Dispose();
                }
            }
            return user;
        }
    }
}
