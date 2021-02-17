using FluentAssertions;
using Microsoft.Extensions.Options;
using NSubstitute;
using Paymentsense.Coding.Challenge.Api.Configuration;
using Paymentsense.Coding.Challenge.Api.Http;
using Paymentsense.Coding.Challenge.Api.Http.Interfaces;
using System.Net.Http;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Clients
{
    public class CountryClientTests
    {
        ICountryClient _countryClient;

        public CountryClientTests()
        {
            var mockConfig = Substitute.For<IOptions<Config>>();
            mockConfig.Value.Returns<Config>(new Config() { CountryApi = "https://restcountries.eu/rest/v2/all"});
            _countryClient = new CountryClient(Substitute.For<HttpClient>(), mockConfig );
        }

        [Fact]
        public async void GetAllCountryDataAsync_Returns_ListOfCountryData()
        {
            var countryData = await _countryClient.GetAllCountryDataAsync();
            countryData.Should().NotBeNull();
            countryData.Count.Should().BeGreaterThan(0);
        }
    }
}
