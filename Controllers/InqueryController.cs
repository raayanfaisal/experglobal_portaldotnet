using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using expertglobal.Model;
using expertglobal.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace expertglobal.Controllers
{
    [Route("api/[controller]")]
    public class InqueryController : Controller
    {
        private readonly InqueryInterface _inqueryservice;

        

        public InqueryController(InqueryInterface _inqueryservice )
        {
            this._inqueryservice = _inqueryservice;
            
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
        public ActionResult Post([FromBody] Inquery value)
        {
            try
            {
                value.Date = DateTime.Now;
                _inqueryservice.Post(value);
                return Ok();
            }
            catch (Exception ex)
            {
               
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
        [HttpGet("get-client-inqueries")]
        public IActionResult GetClientOwnInquery([FromRoute]string idcard)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
