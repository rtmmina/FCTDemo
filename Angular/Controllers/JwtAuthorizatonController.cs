using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.DTO;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtAuthorizatonController : ControllerBase
    {
        private const string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        // GET: api/JwtAuthorizaton
        [HttpGet]
        public Token Get()
        {
            return new Token()
            {
                Email = "Email",
                JwtToken = "Token"
            };
        }

        // GET: api/JwtAuthorizaton/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(string id)
        {
            return $"{id}New";
        }

        // POST: api/JwtAuthorizaton
        [HttpPost]
        [Route("BuildJwt")]
        public Token Post([FromBody] Token value)
        {
            if (value.JwtToken.Trim() == string.Empty)
                value.JwtToken = GenerateToken(value.Email);
            else
                value.Email = ReadEmailValue(value.JwtToken);
            return value;
        }

        private string ReadEmailValue(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                
                return jwtToken.Claims.ToList()[0].Value;
            }
            catch (Exception)
            {
                //should write log
                return null;
            }
        }

        // PUT: api/JwtAuthorizaton/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost]
        public PurchaseDetails Post([FromBody] PurchaseDetails value)
        {
            return value;
        }

        public static string GenerateToken(string email, int expireMinutes = 20)
        {
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, email)
                }),

                Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(symmetricKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }
    }
}


