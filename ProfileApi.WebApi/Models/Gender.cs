using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileApi.WebApi.Models
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Person> People { get; set; }
    }
}
