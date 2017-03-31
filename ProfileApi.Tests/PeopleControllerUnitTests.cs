using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProfileApi.WebApi.Controllers;
using ProfileApi.WebApi.Data;
using ProfileApi.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProfileApi.Tests
{
    [TestClass]
    public class PeopleControllerUnitTests
    {
        private Mock<IPersonRepository> repositoryContext;
        private PeopleController subject;

        [TestMethod]
        public async Task TestGet()
        {
            var id = 1;
            repositoryContext = new Mock<IPersonRepository>();
            repositoryContext.Setup(mock => mock.FindAsync(It.IsAny<int>())).Returns(Task.Run(() => new Person
            {
                Id = id
            }));
            subject = new PeopleController(repositoryContext.Object);

            var result = await subject.Get(1) as OkObjectResult;
            
            Assert.IsNotNull(result?.Value);
            var person = result?.Value as Person;
            Assert.IsNotNull(person);
            Assert.AreEqual(id, person?.Id);
        }
    }
}
