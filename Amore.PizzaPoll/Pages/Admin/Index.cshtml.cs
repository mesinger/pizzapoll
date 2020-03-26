using System.Threading.Tasks;
using Amore.Domain.Context;
using Amore.Domain.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Amore.PizzaPoll.Pages.Admin
{
    public class AdminIndexModel : PageModel
    {
        private readonly IAmoreOrderService _orderService;
        private readonly IAmoreCheckoutDataProvider _checkoutDataProvider;

        public AdminIndexModel(IAmoreOrderService orderService, IAmoreCheckoutDataProvider checkoutDataProvider)
        {
            _orderService = orderService;
            _checkoutDataProvider = checkoutDataProvider;
        }

        public bool HasCurrentSession { get; private set; }
        public string CurrentSessionId { get; private set; }

        public void OnGet()
        {
            HasCurrentSession = _checkoutDataProvider.HasCurrentSession();
            CurrentSessionId = _checkoutDataProvider.AmoreSessionId;
        }

        public async Task<IActionResult> OnGetOpenSession()
        {
            if (!_checkoutDataProvider.HasCurrentSession())
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