using Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonReader.Decorators
{
    public class RetryReader : IPersonReader
    {
        private IPersonReader _wrappedReader;
        private int retryCount = 0;

        public RetryReader(IPersonReader wrappedReader)
        {
            _wrappedReader = wrappedReader;
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            retryCount++;
            try
            {
                var people = await _wrappedReader.GetPeople();
                retryCount = 0;
                return people;
            }
            catch (Exception)
            {
                if (retryCount >= 3)
                    throw;
                await Task.Delay(3000);
                return await this.GetPeople();
            }
        }

        public async Task<Person> GetPerson(int id)
        {
            retryCount++;
            try
            {
                var person = await _wrappedReader.GetPerson(id);
                retryCount = 0;
                return person;
            }
            catch (Exception)
            {
                if (retryCount >= 3)
                    throw;
                await Task.Delay(3000);
                return await this.GetPerson(id);
            }
        }
    }
}
