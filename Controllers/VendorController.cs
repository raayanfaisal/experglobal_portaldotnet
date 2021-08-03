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
    public class VendorController : Controller
    {
        private readonly VendorInterface _vendorService;

        public VendorController(VendorInterface _vendorService)
        {
            this._vendorService = _vendorService;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(new { data = _vendorService.Get() });
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            try
            {
                return Ok(new { data = _vendorService.Get(id) });
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Vendor value)
        {
            try
            {
                _vendorService.Post(value);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Vendor value)
        {
            try
            {
                _vendorService.Put(id, value);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            try
            {
                _vendorService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpGet("get-vendor-data/{id}")]
        public IActionResult GetVendoReg([FromRoute] string id)
        {
            try
            {
                return Ok(new { data = _vendorService.GetVenderId(id) });
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
