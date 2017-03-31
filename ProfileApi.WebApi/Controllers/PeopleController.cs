using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileApi.WebApi.Data;
using ProfileApi.WebApi.Models;

namespace ProfileApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private readonly PersonContext context;
        public PeopleController(PersonContext context)
        {
            this.context = context;
        }

        // GET api/people
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await context.People.Include(p => p.Gender).ToListAsync());
        }

        // GET api/people/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var entity = await context.People.Include(p => p.Gender).SingleOrDefaultAsync(p =>
                p.Id == id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        // POST api/people
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/people/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/people/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
