using System;
using Amore.Domain.Context;
using Microsoft.Extensions.Logging;

namespace amore.domain.Site
{
    public class PizzaSiteProxyFactory : IPizzaSiteProxyFactory
    {
        private readonly ILogger<IPizzaSiteProxy> _loggerAmore;
        private readonly IAmoreCheckoutDataProvider _amoreCheckoutDataProvider;

        public PizzaSiteProxyFactory(ILogger<IPizzaSiteProxy> loggerAmore, IAmoreCheckoutDataProvider amoreCheckoutDataProvider)
        {
            _loggerAmore = loggerAmore;
            _amoreCheckoutDataProvider = amoreCheckoutDataProvider;
        }

        public IPizzaSiteProxy Create(PizzaPlace pizzaPlace)
        {
            return pizzaPlace switch
            {
                PizzaPlace.AMORE => new AmorePizzaSiteSubject(_loggerAmore, _amoreCheckoutDataProvider),
                _ => null
            };
        }
    }
}