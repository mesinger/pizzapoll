using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Amore.Data.Website.Context;
using Amore.Domain.Data.Provider;
using Microsoft.Extensions.Logging;

namespace Amore.Data.Website.Provider
{
    public class ThatsAmoreWebSiteAccessProvider : IThatsAmoreWebSiteAccessProvider
    {
        private readonly ILogger<ThatsAmoreWebSiteAccessProvider> _logger;
        private readonly ISessionProvider _sessionProvider;

        public ThatsAmoreWebSiteAccessProvider(ILogger<ThatsAmoreWebSiteAccessProvider> logger, ISessionProvider sessionProvider)
        {
            _logger = logger;
            _sessionProvider = sessionProvider;
        }

        public async Task<string> GetSessionId()
        {
            try
            {
                using var client = new HttpClient();
                var response = await client.GetAsync("http://www.thatsamore.at/cart");

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Unable to retrieve session id from thatsamore: HTTP Status Code {code}", response.StatusCode);
                    return string.Empty;
                }

                return ParseSessionIdFromResponse(response);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogWarning("Unable to retrieve session id from thatsamore: {msg}", ex.Message);
                return string.Empty;
            }
        }

        public void PutOrder(IEnumerable<KeyValuePair<string, string>> orderData)
        {
            PostRequestWithSessionId("http://www.thatsamore.at/orders/populate", orderData);
        }

        public void PrepareCheckout()
        {
            throw new NotImplementedException();
        }

        private static string ParseSessionIdFromResponse(HttpResponseMessage response)
        {
            var sessionCookie =
                response.Headers.FirstOrDefault(header => header.Key == "Set-Cookie")
                    .Value.FirstOrDefault(cookie => cookie.StartsWith("_thatsamore_session"));

            if (string.IsNullOrWhiteSpace(sessionCookie))
            {
                return string.Empty;
            }

            return sessionCookie
                .TrimStart("_thatsamore_session=".ToCharArray())
                .TrimEnd("; path=/; HttpOnly".ToCharArray());
        }

        private async void PostRequestWithSessionId(string url, IEnumerable<KeyValuePair<string, string>> data)
        {
            if (!_sessionProvider.HasCurrentSession())
            {
                _logger.LogWarning("Trying to invoke thatsamore.at request without a session id");
                return;
            }
            
            try
            {
                var baseAddress = new Uri(url);
                var cookieContainer = new CookieContainer();
                using var handler = new HttpClientHandler() {CookieContainer = cookieContainer};
                using var client = new HttpClient(handler) {BaseAddress = baseAddress};

                var content = new FormUrlEncodedContent(data);
                cookieContainer.Add(baseAddress, new Cookie("_thatsamore_session", $"{_sessionProvider.GetCurrentSession()}"));
                var result = await client.PostAsync(baseAddress, content);

                if (!result.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Request to {url} failed with status code {code}", result.StatusCode);
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogWarning("Request to {url} failed because of {msg}", url, ex.Message);
            }
        }
    }
}