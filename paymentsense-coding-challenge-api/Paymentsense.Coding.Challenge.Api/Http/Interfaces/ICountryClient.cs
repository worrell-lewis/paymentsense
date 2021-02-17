using Paymentsense.Coding.Challenge.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Http.Interfaces
{
    public interface ICountryClient
    {
        Task<List<CountryData>> GetAllCountryDataAsync();
    }
}
