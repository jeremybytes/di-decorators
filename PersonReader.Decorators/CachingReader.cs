using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonReader.Decorators
{
    public class CachingReader : IPersonReader
    {
        private IPersonReader _wrappedReader;
        private TimeSpan _cacheDuration;

        private IEnumerable<Person> _cachedItems;
        private DateTime _dataDateTime;

        public CachingReader(IPersonReader wrappedReader,
            TimeSpan duration)
        {
            _wrappedReader = wrappedReader;
            _cacheDuration = duration;
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            await ValidateCache();
            return _cachedItems;
        }

        public async Task<Person> GetPerson(int id)
        {
            await ValidateCache();
            return _cachedItems.FirstOrDefault(p => p.Id == id);
        }

        private bool IsCacheValid
        {
            get
            {
                if (_cachedItems == null)
                    return false;
                var _cacheAge = DateTime.Now - _dataDateTime;
                return _cacheAge < _cacheDuration;
            }
        }

        private async Task ValidateCache()
        {
            if (IsCacheValid)
                return;

            try
            {
                _cachedItems = await _wrappedReader.GetPeople();
                _dataDateTime = DateTime.Now;
            }
            catch
            {
                _cachedItems = new List<Person>()
                {
                    new Person()
                    { GivenName = "No Data Available",
                      FamilyName = string.Empty, Rating = 0,
                      StartDate = DateTime.Today},
                };
                InvalidateCache();
            }
        }

        private void InvalidateCache()
        {
            _dataDateTime = DateTime.MinValue;
        }
    }
}
