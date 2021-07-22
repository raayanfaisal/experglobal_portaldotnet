using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using expertglobal.Data;
using expertglobal.Model;
using expertglobal.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace expertglobal.Controllers
{
    [Route("api/[controller]")]
    public class SecurityController : Controller
    {

        private readonly DataDbContext _db;

        private readonly UserManager<IdentityUser> _um;
        private readonly SignInManager<IdentityUser> _sm;
        private readonly RoleManager<IdentityRole> _rm;
        private readonly IPasswordHasher<IdentityUser> _ih;
        IPasswordHasher<IdentityUser> _hasher;
        private IConfiguration _config;



        public SecurityController(

             IPasswordHasher<IdentityUser> _hasher,
             IConfiguration config,
             UserManager<IdentityUser> _um,
             SignInManager<IdentityUser> _sm,
             RoleManager<IdentityRole> _rm,
             IPasswordHasher<IdentityUser> _ih,
             DataDbContext _db)
        {

            this._um = _um;
            this._sm = _sm;
            this._rm = _rm;
            this._ih = _ih;
            this._db = _db;
            this._hasher = _hasher;

            _config = config;
        }

        

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public  async Task<IActionResult >Post([FromBody] User value)
        {
            try
            {
                var user = await _um.FindByNameAsync(value.UserName);
                if (user != null)
                {
                    if (_hasher.VerifyHashedPassword(user, user.PasswordHash, value.Password) == PasswordVerificationResult.Success)
                    {
                        var Roles = await _um.GetRolesAsync(user);
                        var cliams = new List<Claim>()


                                {
                                    new Claim(JwtRegisteredClaimNames.Sub,value.UserName),
                                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                                };
                        List<string> CRoles = new List<string>();
                        foreach (var item in Roles)
                        {
                            CRoles.Add(item);
                            cliams.Add(new Claim(ClaimTypes.Role, item));
                        }

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT-Token:auth-token-key"]));

                        var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            issuer: "http://localhost:5000",
                            audience: "http://localhost:5000",
                            claims: cliams,
                            expires: DateTime.UtcNow.AddMinutes(1440),
                            signingCredentials: credential
                        );

                        var ac = new AuditLog
                        {
                            Action = $"{value.UserName} loginto system",
                            Date = DateTime.Now,

                            Task = "Auth User"
                        };
                        _db.AuditLogs.Add(ac);
                        _db.SaveChanges();


                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expier = token.ValidTo,
                            user = value.UserName,
                            roles = CRoles
                        });


                    }
                }
                return BadRequest("failed to generate token");


            }
            catch (Exception)
            {

                //return StatusCode(500);
                throw;
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
