using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using expertglobal.Data;
using expertglobal.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace expertglobal.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private readonly DataDbContext _db;
        private AuthClientInterface _clientService;
        private readonly UserManager<IdentityUser> _um;
        private readonly SignInManager<IdentityUser> _sm;
        private readonly RoleManager<IdentityRole> _rm;
        private readonly IPasswordHasher<IdentityUser> _ih;

        public AdminController(AuthClientInterface _clientService,
            UserManager<IdentityUser> _um,
            SignInManager<IdentityUser> _sm,
            RoleManager<IdentityRole> _rm,
            IPasswordHasher<IdentityUser> _ih,
            DataDbContext _db)
        {
            this._clientService = _clientService;
            this._um = _um;
            this._sm = _sm;
            this._rm = _rm;
            this._ih = _ih;
            this._db = _db;

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
        public void Post([FromBody] string value)
        {
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
        [HttpGet("accept-client-reg/{id}")]
        public async Task <IActionResult> AcceptClientReg([FromRoute] int id)
        {
            try
            {
                var result =  await _clientService.Approve(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
                return StatusCode(500);
            }
        }
        [HttpGet("seed-roles")]
        public async Task<IActionResult> GenRole()
        {

            string[] roles = { "Admin","Staffs", "client" };
            foreach (var item in roles)
            {
                var d = await _rm.CreateAsync(new IdentityRole(item));
                if (d.Succeeded)
                {
                    continue;
                }
            }

            return Ok(new { date = "roles created" });
        }
    }
}
