using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonReader.Decorator.Tests
{
    public class CountedReader : IPersonReader
    {
        public int CallCount { get; set; }

        public Task<IEnumerable<Person>> GetPeople()
        {
            CallCount++;
            IEnumerable<Person> empty = new List<Person>();
            return Task.FromResult(empty);
        }

        public Task<Person> GetPerson(int id)
        {
            CallCount++;
            Person empty = new Person();
            return Task.FromResult(empty);
        }
    }
}
