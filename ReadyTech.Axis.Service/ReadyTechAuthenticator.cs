using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Text;

namespace ReadyTech.Axis.Service
{
    public class ReadyTechAuthenticator : IAuthenticator
    {
        private readonly string _Base64KeyAndSecret;

        public ReadyTechAuthenticator(string accessToken, string secretToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("message", nameof(accessToken));
            }

            if (string.IsNullOrWhiteSpace(secretToken))
            {
                throw new ArgumentException("message", nameof(secretToken));
            }

            byte[] accessTokenBytes = Encoding.UTF8.GetBytes($"{accessToken}:{secretToken}");
            _Base64KeyAndSecret = Convert.ToBase64String(accessTokenBytes);
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            if (client is null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            request.AddHeader("Authorization", $"Basic {_Base64KeyAndSecret}");
            request.AddHeader("accept", "application/json");
        }
    }
}
