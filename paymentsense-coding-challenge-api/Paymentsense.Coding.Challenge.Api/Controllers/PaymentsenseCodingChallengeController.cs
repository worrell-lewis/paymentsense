using Microsoft.AspNetCore.Mvc;
using Paymentsense.Coding.Challenge.Api.Http.Interfaces;
using Paymentsense.Coding.Challenge.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsenseCodingChallengeController : ControllerBase
    {
        private readonly ICountryClient _countryClient;

        public PaymentsenseCodingChallengeController(ICountryClient countryClient)
        {
            _countryClient = countryClient;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("Paymentsense Coding Challenge!");
        }


        [HttpGet("AllCountryData")]
        public async Task<IActionResult> GetAllCountryData()
        {
            List<CountryData> allCountryData = null;

            try
            {
                allCountryData = await _countryClient.GetAllCountryDataAsync();
            }
            catch(Exception)
            {
                return BadRequest("Error while retreiving country data.");
            }

            return Ok(allCountryData);
        }
    }
}
