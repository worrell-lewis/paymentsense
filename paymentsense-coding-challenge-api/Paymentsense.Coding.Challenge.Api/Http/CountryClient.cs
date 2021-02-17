using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Paymentsense.Coding.Challenge.Api.Configuration;
using Paymentsense.Coding.Challenge.Api.Http.Interfaces;
using Paymentsense.Coding.Challenge.Api.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Http
{
    public class CountryClient : ICountryClient
    {
        private readonly IOptions<Config> _config;
        private readonly HttpClient _httpClient;

        public CountryClient(HttpClient httpClient, IOptions<Config> config)
        {
            _config = config;
            _httpClient = httpClient;
        }

        public async Task<List<CountryData>> GetAllCountryDataAsync()
        {
            List<CountryData> allCountryData = null;
            var response = await _httpClient.GetAsync(new System.Uri($"{_config.Value.CountryApi}"));

            if(response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                allCountryData  =JsonConvert.DeserializeObject<List<CountryData>>(responseString);
            }

            return allCountryData;
        }
    }
}
