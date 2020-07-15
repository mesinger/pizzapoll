using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Amore.PizzaPoll.Pages.Order
{
    public class Error : PageModel
    {
        public string ErrorMessage { get; private set; }
        
        public void OnGet(string message)
        {
            ErrorMessage = message;
        }
    }
}