using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ProfileApi.WebApi.Data;

namespace ProfileApi.WebApi.Migrations
{
    [DbContext(typeof(PersonContext))]
    partial class PersonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProfileApi.WebApi.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("ProfileApi.WebApi.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<int>("GenderId");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("TimeCreated");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("ProfileApi.WebApi.Models.Person", b =>
                {
                    b.HasOne("ProfileApi.WebApi.Models.Gender", "Gender")
                        .WithMany("People")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
