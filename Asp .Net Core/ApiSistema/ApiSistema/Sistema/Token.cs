using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiSistema.Sistema
{
    public class Token
    {
        public static string GenerarToken(string usuario, int id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(BDParametros.ApiKeyToken));
            var credeciales = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Usuario", usuario),
                new Claim("Id", id.ToString())
            };
            var token = new JwtSecurityToken(
                "http://localhost:3000",
                "http://localhost:3000",
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(100),
                
                signingCredentials: credeciales);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
