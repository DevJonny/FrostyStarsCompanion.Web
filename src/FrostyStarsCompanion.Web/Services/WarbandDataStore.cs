using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FrostyStarsCompanion.Web.Model.Frostgrave;

namespace FrostyStarsCompanion.Web.Services
{
    public class WarbandDataStore : IDataStore<Warband>
    {
        private readonly HttpClient _httpClient;
        private List<Warband> _warbands;

        public WarbandDataStore(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Warband>> GetAll()
        {
            if (_warbands is null)
                await FetchData();

            return _warbands;
        }

        public async Task<Warband> Get(Guid id)
        {
            if (_warbands is null)
                await FetchData();

            return _warbands.FirstOrDefault(w => w.Id == id) ?? new Warband();
        }

        private async Task FetchData()
        {
            var data = await _httpClient.GetFromJsonAsync<FrostgraveData>("data/frostgrave.json", new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                PropertyNameCaseInsensitive = true
            });

            _warbands = data.Warbands;
        }
    }
}