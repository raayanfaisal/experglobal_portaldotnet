using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using expertglobal.Data;
using expertglobal.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace expertglobal.Services
{
    public class AutherUserService : SecurityInterface
    {
        private readonly DataDbContext _db;

        private readonly UserManager<UserBio> _um;
        private readonly SignInManager<UserBio> _sm;
        private readonly RoleManager<IdentityRole> _rm;
        private readonly IPasswordHasher<UserBio> _ih;
        IPasswordHasher<UserBio> _hasher;
        private IConfiguration _config;



        public AutherUserService(
           
             IPasswordHasher<UserBio> _hasher,
             IConfiguration config,
             UserManager<UserBio> _um,
             SignInManager<UserBio> _sm,
             RoleManager<IdentityRole> _rm,
             IPasswordHasher<UserBio> _ih,
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



        public async Task<object> AuthUser(User value)
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


                        return new TokenModel
                        {
                            
                            Roles = CRoles,
                            Token = new JwtSecurityTokenHandler().WriteToken(token),
                            User = user.FullName,
                            IDcard = value.UserName
                             
                        };

                       

                    }
                }
                return new TokenModel {

                };


            }
            catch (Exception)
            {

                //return StatusCode(500);
                throw;
            }

        }
    }
}
