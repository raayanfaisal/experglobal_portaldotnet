using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using expertglobal.Data;
using expertglobal.Model;
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
        private readonly UserManager<UserBio> _um;
        private readonly SignInManager<UserBio> _sm;
        private readonly RoleManager<IdentityRole> _rm;
        private readonly IPasswordHasher<UserBio> _ih;

        public AdminController(AuthClientInterface _clientService,
            UserManager<UserBio> _um,
            SignInManager<UserBio> _sm,
            RoleManager<IdentityRole> _rm,
            IPasswordHasher<UserBio> _ih,
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
                bool result =  await _clientService.Approve(id);
                if (result == true)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(500);
                }
              
            }
            catch (Exception ex)
            {
                
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
        [HttpPost("register-user")]
        public async Task< IActionResult> RegUser([FromBody] User value)
        {
            try
            {
                bool result = await _clientService.RegUser(value);
                if (result == true)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(404);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpGet("get-user")]
        public  async Task<IActionResult> GetUsers()
        {
            try
            {
                return Ok( await _clientService.GetAllUsers());
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
