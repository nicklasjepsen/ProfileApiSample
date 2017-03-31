using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProfileApi.WebApi.Models;

namespace ProfileApi.WebApi.Data
{
    public class DbInitializer
    {
        public async static Task Initialize(PersonContext context)
        {
            // Using EF migrations to a. Create the DB if not exist or b. migrate the database if it exists 
            context.Database.Migrate();

            // Only seed database if it's empty
            if (context.People.Any())
                return;

            var genders = new[]
            {
                new Gender
                {
                    Name = "Male"
                },
                new Gender
                {
                    Name = "Female"
                },
                new Gender
                {
                    Name = "Other"
                }
            };
            await context.Genders.AddRangeAsync(genders);

            var people = new[]
            {
                new Person
                {
                    GenderId = 1,
                    FirstName = "Nicklas",
                    LastName = "Møller Jepsen",
                    Email = "nicklas.m.jepsen@gmail.com",
                    TimeCreated = DateTime.UtcNow
                },
                new Person
                {
                    GenderId = 2,
                    FirstName = "Holly",
                    LastName = "Molly",
                    Email = "holly.molly@gmail.com",
                    TimeCreated = DateTime.UtcNow
                }
            };
            await context.People.AddRangeAsync(people);
        }
    }
}
