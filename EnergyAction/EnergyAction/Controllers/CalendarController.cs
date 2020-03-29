using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;
using Model;

namespace EnergyAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly IEventService _service;
        public CalendarController(IEventService service)
        {
            _service = service;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<List<Event>> Get()
        {
            return _service.GetAllEvents();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Event> Get(int id)
        {
            Event eventDetails = _service.GetEvent(id);
            return eventDetails;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Event value)
        {
            _service.InsertEvent(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event value)
        {
           _service.UpdateEvent(id, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteEvent(id);
        }
    }
}
