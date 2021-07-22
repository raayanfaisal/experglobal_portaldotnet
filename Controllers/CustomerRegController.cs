using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using expertglobal.Model;
using expertglobal.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace expertglobal.Controllers
{
    [Route("api/[controller]")]
    public class CustomerRegController : Controller
    {
        private readonly AuthClientInterface _clientService;
        public CustomerRegController(AuthClientInterface _clientService)
        {
            this._clientService = _clientService;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(new { data = _clientService.Get() });
            }
            catch (Exception ex)
            {
                throw;
                return StatusCode(500);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] OnlineClientReg value)
        {
            try
            {
                _clientService.Post(value);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
                return StatusCode(500);
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
