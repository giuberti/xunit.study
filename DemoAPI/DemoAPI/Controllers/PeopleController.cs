using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DemoPeople;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        // GET: api/<PeopleController>
        [HttpGet]
        public ActionResult<List<PersonModel>> Get()
        {
            return DataAccess.GetAllPeople();
        }

        // POST api/<PeopleController>
        [HttpPost]
        [Consumes("application/json")]
        public ActionResult Post([FromBody] PersonModel value)
        {
            DataAccess.AddPerson(value);
            return Ok();
        }
    }
}
