using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProfileApi.WebApi.Models;

namespace ProfileApi.WebApi.Data
{
    public interface IPersonRepository
    {
        Task<Person> AddAsync(Person item);
        IEnumerable<Person> GetAll();
        Task<Person> FindAsync(int personId);
        Task RemoveAsync(int personId);
        Task UpdateAsync(Person person);
    }

    public class PersonRepository : IPersonRepository
    {
        private readonly PersonContext context;

        public PersonRepository(PersonContext context)
        {
            this.context = context;
        }

        public async Task<Person> AddAsync(Person item)
        {
            context.Add(item);
            await context.SaveChangesAsync();

            return item;
        }

        public IEnumerable<Person> GetAll()
        {
            return context.People.Include(p => p.Gender);
        }

        public async Task<Person> FindAsync(int id)
        {
            return await context.People.Include(p => p.Gender).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await context.People.SingleOrDefaultAsync(p => p.Id == id);
            if (entity == null)
                throw new InvalidOperationException("No person found matching id " + id);

            context.People.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Person item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            context.People.Update(item);
            await context.SaveChangesAsync();
        }
    }
}
