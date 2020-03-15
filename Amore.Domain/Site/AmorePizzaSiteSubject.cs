using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Amore.Domain.Context;
using Microsoft.Extensions.Logging;

namespace amore.domain.Site
{
    internal class AmorePizzaSiteSubject : IPizzaSiteProxy
    {
        private readonly ILogger<IPizzaSiteProxy> _logger;
        private readonly IAmoreCheckoutDataProvider _amoreCheckoutDataProvider;

        public AmorePizzaSiteSubject(ILogger<IPizzaSiteProxy> logger,
            IAmoreCheckoutDataProvider amoreCheckoutDataProvider)
        {
            _logger = logger;
            _amoreCheckoutDataProvider = amoreCheckoutDataProvider;
        }

        public async Task<string> GetSessionId()
        {
            try
            {
                using var client = new HttpClient();
                var response = await client.GetAsync("http://www.thatsamore.at/cart");

                if (!response.IsSuccessStatusCode)
                {
                    return string.Empty;
                }

                return ParseSessionIdFromResponse(response);
            }
            catch (HttpRequestException)
            {
                return string.Empty;
            }
        }

        public async void PutOrder(string sessionId, IEnumerable<KeyValuePair<string, string>> orderData)
        {
            try
            {
                var baseAddress = new Uri("http://www.thatsamore.at/orders/populate");
                var cookieContainer = new CookieContainer();
                using var handler = new HttpClientHandler() {CookieContainer = cookieContainer};
                using var client = new HttpClient(handler) {BaseAddress = baseAddress};

                var content = new FormUrlEncodedContent(orderData);
                cookieContainer.Add(baseAddress, new Cookie("_thatsamore_session", $"{sessionId}"));
                var result = await client.PostAsync(baseAddress, content);

                if (!result.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Adding order to cart failed with status code {code}", result.StatusCode);
                }
            }
            catch (HttpRequestException)
            {
            }
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
    }
}