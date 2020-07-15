using System.Threading.Tasks;
using Amore.Data.Website.Context;
using Amore.Domain.Data.Model;
using Amore.Domain.Data.Provider;
using Amore.Domain.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Amore.PizzaPoll.Pages.Admin
{
    public class AdminIndexModel : PageModel
    {
        private readonly IAmoreOrderService _orderService;
        private readonly ISessionProvider _sessionProvider;

        public AdminIndexModel(IAmoreOrderService orderService, ISessionProvider sessionProvider, IAmoreCheckoutDataProvider checkoutDataProvider)
        {
            _orderService = orderService;
            _sessionProvider = sessionProvider;
            CheckoutDataProvider = checkoutDataProvider;
        }

        public bool HasCurrentSession { get; private set; }
        public string CurrentSessionId { get; private set; }
        public CompleteOrderInfo OrderInfo { get; private set; }
        public IAmoreCheckoutDataProvider CheckoutDataProvider { get; }

        public async void OnGet()
        {
            HasCurrentSession = _sessionProvider.HasCurrentSession();
            CurrentSessionId = _sessionProvider.GetCurrentSession();
            OrderInfo = await _orderService.GetOrderInfo();
        }

        public async Task<IActionResult> OnGetOpenSession()
        {
            if (!_sessionProvider.HasCurrentSession())
            {
                await _orderService.OpenSession();
            }
            
            return RedirectToPage("Index");
        }

        public IActionResult OnGetCloseSession()
        {
            if (_sessionProvider.HasCurrentSession())
            {
                _orderService.Checkout();
                _sessionProvider.ReleaseCurrentSession();
            }

            return RedirectToPage("Index");
        }
    }
}