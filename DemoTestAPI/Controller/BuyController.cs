using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using DemoAPI.Models;
using DemoAPI.Services;


namespace DemoAPI.Controller
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class BuyController : ControllerBase
    {
        private readonly IBuyService _service;
        public BuyController(IBuyService service)
        {
            _service = service;
        }
        //GET v1/api/Buy
        [HttpGet]
        public ActionResult<IEnumerable<BuyItem>> Get()
        {
            var items = _service.GetAllItems();
            return Ok(items);
        }
        // GET v1/api/buy/5
        [HttpGet("{id}")]
        public ActionResult<BuyItem> Get(int id)
        {
            var item = _service.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        // POST v1/api/buy
        [HttpPost]
        public ActionResult Post([FromBody] BuyItem value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _service.Add(value);
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }
        // DELETE v1/api/buy/5
        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var existingItem = _service.GetById(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            _service.Remove(id);
            return Ok();
        }
    }
}
