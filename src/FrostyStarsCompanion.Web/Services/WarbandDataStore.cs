using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FrostyStarsCompanion.Web.Model.Frostgrave;

namespace FrostyStarsCompanion.Web.Services
{
    public class WarbandDataStore : IDataStore<Warband>
    {
        private readonly HttpClient _httpClient;
        private List<Warband> _warbands = null;

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

            return _warbands.FirstOrDefault(w => w.Id == id);
        }

        private async Task FetchData()
        {
            _warbands = await _httpClient.GetFromJsonAsync<List<Warband>>("data/frostgrave.json");
        }
    }
}