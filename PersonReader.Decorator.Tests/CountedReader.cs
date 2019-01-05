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

        public async Task<IEnumerable<Person>> GetPeople()
        {
            await Task.Delay(1);
            CallCount++;
            return new List<Person>();
        }

        public async Task<Person> GetPerson(int id)
        {
            await Task.Delay(1);
            CallCount++;
            return new Person();
        }
    }
}
