using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PersonReader.Decorators
{
    public class ExceptionLoggingReader : IPersonReader
    {
        IPersonReader _wrappedReader;

        public ExceptionLoggingReader(IPersonReader wrappedReader)
        {
            _wrappedReader = wrappedReader;
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            try
            {
                return await _wrappedReader.GetPeople();
            }
            catch (Exception ex)
            {
                LogException(ex);
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
                LogException(ex);
                throw;
            }
        }

        private async void LogException(Exception ex)
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "ExceptionLog.txt";
            using (var sr = new StreamWriter(filePath, true))
            {
                await sr.WriteLineAsync("--------------------------------------");
                await sr.WriteLineAsync($"START {DateTime.Now}");
                await sr.WriteLineAsync("EXCEPTION");
                await sr.WriteLineAsync($"{ex}");
                await sr.WriteLineAsync($"END {DateTime.Now}");
                await sr.WriteLineAsync("--------------------------------------");
            }
        }
    }
}
