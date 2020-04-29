using RestSharp;
using System;
using Xunit;

namespace ReadyTech.Axis.Service.Tests
{
    public class ReadyTechServiceTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("", null)]
        [InlineData(null, "")]
        [InlineData(" ", "")]
        [InlineData("", " ")]
        public void ReadyTechAuthenticatorThrowsAccessTokenOrSecretTokenIsInvalid(string accessToken, string secretToken)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ReadyTechAuthenticator service = new ReadyTechAuthenticator(accessToken, secretToken);
            });
        }

        [Fact]
        public void ReadyTechAuthenticatorAuthenticateThrowsIfClientOrRequestIsInvalid()
        {
            ReadyTechAuthenticator authenticator = new ReadyTechAuthenticator("test", "test");
            Assert.Throws<ArgumentNullException>(() =>
            {
                authenticator.Authenticate(null, new RestRequest());
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                authenticator.Authenticate(new RestClient(), null);
            });

        }

        [Theory]
        [InlineData("", "")]
        [InlineData("", null)]
        [InlineData(null, "")]
        [InlineData(" ", "")]
        [InlineData("", " ")]
        public void ConstructorThrowsIfAccessTokenOrSecretTokenIsInvalid(string accessToken, string secretToken)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ReadyTechService service = new ReadyTechService(accessToken, secretToken);
            });
        }

        [Fact]
        public void CreateEventThrowsIfEventIsNull()
        {
            ReadyTechService service = new ReadyTechService("abc", "xyz");
            Assert.Throws<ArgumentNullException>(() =>
            {
                service.CreateEvent(null);
            });
        }

        [Fact]
        public void UpdateEventThrowsIfEventIsNull()
        {
            ReadyTechService service = new ReadyTechService("abc", "xyz");
            Assert.Throws<ArgumentNullException>(() =>
            {
                service.UpdateEvent(null);
            });
        }

        [Fact]
        public void UpdateSeatThrowsIfSeatIsNull()
        {
            ReadyTechService service = new ReadyTechService("abc", "xyz");
            Assert.Throws<ArgumentNullException>(() =>
            {
                service.UpdateSeat(null);
            });
        }
    }
}
