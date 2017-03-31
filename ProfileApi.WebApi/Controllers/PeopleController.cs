using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfileApi.WebApi.Data;
using ProfileApi.WebApi.Models;

namespace ProfileApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private readonly IPersonRepository repository;
        public PeopleController(IPersonRepository repository)
        {
            this.repository = repository;
        }

        // GET api/people
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repository.GetAll());
        }

        // GET api/people/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var entity = await repository.FindAsync(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        // POST api/people
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Person model)
        {
            if (model == null)
                return BadRequest("Please provide a Person.");
            if (string.IsNullOrEmpty(model.Email))
                return BadRequest("An email address is required.");

            var entity = await repository.AddAsync(model);

            return CreatedAtRoute(nameof(Get), entity.Id, entity);
        }

        // PUT api/people/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Person model)
        {
            if (model == null || model.Id != id)
            {
                return BadRequest();
            }

            var entity = await repository.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            await repository.UpdateAsync(model);
            return new NoContentResult();
        }

        // DELETE api/people/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await repository.RemoveAsync(id);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
                return BadRequest("No Person found with id " + id);
            }

            return new NoContentResult();
        }
    }
}
