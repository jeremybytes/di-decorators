using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleViewer.Presentation.Tests
{
    public class FakeRepository : IPersonReader
    {

        public async Task<IEnumerable<Person>> GetPeople()
        {
            await Task.Delay(1);
            var people = new List<Person>()
            {
                new Person() {Id = 1,
                    GivenName = "John", FamilyName = "Smith",
                    Rating = 7, StartDate = new DateTime(2000, 10, 1)},
                new Person() {Id = 2,
                    GivenName = "Mary", FamilyName = "Thomas",
                    Rating = 9, StartDate = new DateTime(1971, 7, 23)},
            };

            return people;
        }

        public async Task<Person> GetPerson(int id)
        {
            var people = await GetPeople();
            return people.FirstOrDefault(p => p.Id == id);
        }
    }
}
