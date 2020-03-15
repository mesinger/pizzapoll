using System.Threading.Tasks;
using Amore.Data.Dao;
using Amore.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.Order
{
    public class IndexOrderModel : PageModel
    {
        private readonly IPizzaDao _pizzaDao;
        private readonly IGoodieDao _goodieDao;

        public IndexOrderModel(IPizzaDao pizzaDao, IGoodieDao goodieDao)
        {
            _pizzaDao = pizzaDao;
            _goodieDao = goodieDao;
        }

        public async Task<IActionResult> OnGet(string pizzaId)
        {
            var pizza = await _pizzaDao.GetById(pizzaId);

            if (pizza == null)
            {
                return NotFound();
            }

            return (pizza.Name) switch
            {
                AmoreConstants.Pizzas.PizzaPane => RedirectToPage("PizzaPane"),
                _ => NotFound()
            };
        }
    }
}