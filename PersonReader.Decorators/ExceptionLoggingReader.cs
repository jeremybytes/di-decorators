using Common;
using Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PersonReader.Decorators
{
    public class ExceptionLoggingReader : IPersonReader
    {
        IPersonReader _wrappedReader;
        ILogger _logger;

        public ExceptionLoggingReader(IPersonReader wrappedReader, 
            ILogger logger)
        {
            _wrappedReader = wrappedReader;
            _logger = logger;
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            try
            {
                return await _wrappedReader.GetPeople();
            }
            catch (Exception ex)
            {
                await _logger?.LogException(ex);
                throw;
            }
        }

        public async Task<Person> GetPerson(int id)
        {
            try
            {
                return await _wrappedReader.GetPerson(id);
            }
            catch (Exception ex)
            {
                await _logger?.LogException(ex);
                throw;
            }
        }
    }
}
