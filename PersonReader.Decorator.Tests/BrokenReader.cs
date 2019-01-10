using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonReader.Decorator.Tests
{
    public class BrokenReader : IPersonReader
    {
        private int brokenCount;
        private int retryCount;

        IEnumerable<Person> testPeople = new List<Person>()
            {
                new Person() {Id = 1,
                    GivenName = "John", FamilyName = "Smith",
                    Rating = 7, StartDate = new DateTime(2000, 10, 1)},
                new Person() {Id = 2,
                    GivenName = "Mary", FamilyName = "Thomas",
                    Rating = 9, StartDate = new DateTime(1971, 7, 23)},
            };

        public BrokenReader(int timesBroken = 0)
        {
            brokenCount = timesBroken;
            retryCount = 0;
        }

        public Task<IEnumerable<Person>> GetPeople()
        {
            if (retryCount < brokenCount)
            {
                retryCount++;
                throw new Exception("Cannot retrieve data");
            }

            return Task.FromResult(testPeople);
        }

        public Task<Person> GetPerson(int id)
        {
            throw new NotImplementedException();
        }
    }
}
