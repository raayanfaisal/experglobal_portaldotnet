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
    public class CustomerController : Controller
    {
        private readonly CustomerInterface _customerService;

        public CustomerController(CustomerInterface _customerService)
        {
            this._customerService = _customerService;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(new { data = _customerService.Get() });
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(new { data = _customerService.Get(id) });
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] CustomerDetail value)
        {
            try
            {
                _customerService.Post(value);
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
        [HttpGet("get-customer-info/{id}")]
        public IActionResult GetCustomerDeatil([FromRoute]int id)
        {
            try
            {
                return Ok(_customerService.GetCustomerId(id) );
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
