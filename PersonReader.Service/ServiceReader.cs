using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PersonReader.Service
{
    public class ServiceReader : IPersonReader
    {
        HttpClient client;

        public ServiceReader()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9874");
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            HttpResponseMessage response = await client.GetAsync("api/people");
            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Person>>(stringResult);
            }
            return new List<Person>();
        }

        public async Task<Person> GetPerson(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"api/people/{id}");
            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Person>(stringResult);
            }
            return new Person();
        }
    }
}
