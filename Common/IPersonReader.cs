using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IPersonReader
    {
        Task<IEnumerable<Person>> GetPeople();
        Task<Person> GetPerson(int id);
    }
}
