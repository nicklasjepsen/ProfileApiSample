using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProfileApi.WebApi.Models;

namespace ProfileApi.WebApi.Data
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Gender> Genders { get; set; }

        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // EF will use names of the DbSets to determine the table name.
            // Here we use the singular form of the object in stead
            modelBuilder.Entity<Person>().ToTable(nameof(Person));
            modelBuilder.Entity<Gender>().ToTable(nameof(Gender));
        }
    }
}
