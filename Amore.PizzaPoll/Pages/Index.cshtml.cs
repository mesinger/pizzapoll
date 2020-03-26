using System.Collections.Generic;
using Amore.Domain.Data.Dao;
using Amore.Domain.Data.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Amore.PizzaPoll.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPizzaDao _pizzaDao;

        public IndexModel(IPizzaDao pizzaDao)
        {
            _pizzaDao = pizzaDao;
        }

        public List<Pizza> Pizzas { get; private set; }
        
        public async void OnGet()
        {
            Pizzas = await _pizzaDao.GetAll();
        }
    }
}