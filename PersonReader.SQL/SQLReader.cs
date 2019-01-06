using Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonReader.SQL
{
    public class SQLReader : IPersonReader
    {
        DbContextOptions<PersonContext> options;

        public SQLReader()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PersonContext>();
            optionsBuilder.UseSqlite("Data Source=People.db");
            options = optionsBuilder.Options;
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            using (var context = new PersonContext(options))
            {
                return await context.People.ToListAsync();
            }
        }

        public async Task<Person> GetPerson(int id)
        {
            using (var context = new PersonContext(options))
            {
                return await context.People.SingleOrDefaultAsync(p => p.Id == id);
            }
        }
    }
}
