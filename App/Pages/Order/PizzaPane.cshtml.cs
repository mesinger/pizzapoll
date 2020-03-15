using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Amore.Data.Dao;
using Amore.Data.Models;
using Amore.Domain.Context;
using Amore.Domain.Order;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace App.Pages.Order
{
    public class PizzaPaneModel : PageModel
    {
        private readonly IPizzaDao _pizzaDao;
        private readonly IGoodieDao _goodieDao;
        private readonly IAmoreCheckoutDataProvider _checkoutDataProvider;
        private readonly IAmoreOrderService _amoreOrderService;
        private readonly ILogger<PizzaPaneModel> _logger;

        public PizzaPaneModel(IPizzaDao pizzaDao, IGoodieDao goodieDao, IAmoreCheckoutDataProvider checkoutDataProvider, IAmoreOrderService amoreOrderService, ILogger<PizzaPaneModel> logger)
        {
            _pizzaDao = pizzaDao;
            _goodieDao = goodieDao;
            _checkoutDataProvider = checkoutDataProvider;
            _amoreOrderService = amoreOrderService;
            _logger = logger;
        }

        public Pizza Pizza { get; private set; }
        public List<Goodie> AdditionalGoodies { get; private set; }
        [BindProperty] public GoodieFormModel FormModel { get; set; }

        public async void OnGet()
        {
            Pizza = await _pizzaDao.GetByName(AmoreConstants.Pizzas.PizzaPane);
            FormModel = new GoodieFormModel();
        }

        public async Task<IActionResult> OnPost()
        {
            if (_checkoutDataProvider.HasCurrentSession())
            {
                Pizza = await _pizzaDao.GetByName(AmoreConstants.Pizzas.PizzaPane);

                if (Pizza == null)
                {
                    _logger.LogInformation("Unable to retrieve pizza pane item");
                    return Page();
                }
                
                AdditionalGoodies = await _goodieDao.GetAllWithId(Pizza.AdditionalGoodiesIds.ToArray());

                _amoreOrderService.Order(Pizza, AdditionalGoodies.Where(goodie => FormModel.SelectedGoodies[goodie.Id]).ToList());
            }
            
            return RedirectToPage("../Index");
        }
    }
}