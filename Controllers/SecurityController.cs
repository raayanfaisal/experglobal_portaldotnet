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

        private readonly SecurityInterface _securityService;
        public SecurityController(SecurityInterface _securityService)
        {
            this._securityService = _securityService;

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
        public async Task<IActionResult> Post([FromBody] User value)
        {
            try
            {

                var x = await _securityService.AuthUser(value);
                TokenModel token = (TokenModel)x;
                if (token.Token != null)
                {
                    return Ok( token );
                }
                else
                {
                    return BadRequest("invalid token");
                }


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
