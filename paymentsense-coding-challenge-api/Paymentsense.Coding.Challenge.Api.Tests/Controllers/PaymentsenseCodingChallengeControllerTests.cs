using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Paymentsense.Coding.Challenge.Api.Controllers;
using Paymentsense.Coding.Challenge.Api.Http.Interfaces;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Controllers
{
    public class PaymentsenseCodingChallengeControllerTests
    {
        private readonly PaymentsenseCodingChallengeController _controller;

        public PaymentsenseCodingChallengeControllerTests()
        {
            var countryClient = Substitute.For<ICountryClient>();
            _controller = new PaymentsenseCodingChallengeController(countryClient);

        }

        [Fact]
        public void Get_OnInvoke_ReturnsExpectedMessage()
        {
            var result = _controller.Get().Result as OkObjectResult;

            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().Be("Paymentsense Coding Challenge!");
        }
    }
}
