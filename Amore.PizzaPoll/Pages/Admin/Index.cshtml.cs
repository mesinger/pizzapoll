using System.Threading.Tasks;
using Amore.Domain.Context;
using Amore.Domain.Data.Model;
using Amore.Domain.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Amore.PizzaPoll.Pages.Admin
{
    public class AdminIndexModel : PageModel
    {
        private readonly IAmoreOrderService _orderService;

        public AdminIndexModel(IAmoreOrderService orderService, IAmoreCheckoutDataProvider checkoutDataProvider)
        {
            _orderService = orderService;
            CheckoutDataProvider = checkoutDataProvider;
        }

        public bool HasCurrentSession { get; private set; }
        public string CurrentSessionId { get; private set; }
        public CompleteOrderInfo OrderInfo { get; private set; }
        public IAmoreCheckoutDataProvider CheckoutDataProvider { get; }

        public async void OnGet()
        {
            HasCurrentSession = CheckoutDataProvider.HasCurrentSession();
            CurrentSessionId = CheckoutDataProvider.AmoreSessionId;
            OrderInfo = await _orderService.GetOrderInfo();
        }

        public async Task<IActionResult> OnGetOpenSession()
        {
            if (!CheckoutDataProvider.HasCurrentSession())
            {
                await _orderService.OpenSession();
            }
            
            return RedirectToPage("Index");
        }

        public IActionResult OnGetCloseSession()
        {
            return RedirectToPage("Index");
        }
    }
}