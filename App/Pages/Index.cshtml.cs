using System.Collections.Generic;
using Amore.Data.Dao;
using Amore.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages
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