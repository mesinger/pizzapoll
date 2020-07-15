using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amore.Data.Website.Context;
using Amore.Domain.Data.Dao;
using Amore.Domain.Data.Model;
using Amore.Domain.Data.Provider;
using Amore.Domain.Order;
using Amore.PizzaPoll.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Amore.PizzaPoll.Pages.Order
{
    public class IndexOrderModel : PageModel
    {
        private readonly IPizzaDao _pizzaDao;
        private readonly IAmoreCheckoutDataProvider _checkoutDataProvider;
        private readonly IGoodieDao _goodieDao;
        private readonly IAmoreOrderService _amoreOrderService;
        private readonly ISessionProvider _sessionProvider;

        public IndexOrderModel(IPizzaDao pizzaDao, IAmoreCheckoutDataProvider checkoutDataProvider, IGoodieDao goodieDao, IAmoreOrderService amoreOrderService, ISessionProvider sessionProvider)
        {
            _pizzaDao = pizzaDao;
            _checkoutDataProvider = checkoutDataProvider;
            _goodieDao = goodieDao;
            _amoreOrderService = amoreOrderService;
            _sessionProvider = sessionProvider;
        }

        public Pizza Pizza { get; private set; }
        public IEnumerable<Goodie> AdditionalGoodies { get; private set; }
        [BindProperty]
        public GoodieFormModel FormModel { get; set; }

        public async Task<IActionResult> OnGet(string pizzaId)
        {
            if (!_sessionProvider.HasCurrentSession())
            {
                return RedirectToPage("../Index");
            }
            
            Pizza = await _pizzaDao.GetById(pizzaId);

            if (Pizza == null)
            {
                return NotFound();
            }

            FormModel = new GoodieFormModel {PizzaId = pizzaId};

            (Pizza.DefaultGoodiesIds as List<string>)?.ForEach(goodieId => FormModel.SelectedGoodies[goodieId] = true);

            AdditionalGoodies = await _goodieDao.GetAllWithId(Pizza.AdditionalGoodiesIds.ToArray());

            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            var pizza = await _pizzaDao.GetById(FormModel.PizzaId);

            if (pizza == null)
            {
                return NotFound();
            }
            
            var selectedGoodieIds = FormModel.SelectedGoodies
                .Where(pair => pair.Value)
                .Select(pair => pair.Key).ToList();

            var goodies = await _goodieDao.GetAllWithId(selectedGoodieIds.ToArray());
            
            _amoreOrderService.PutOrder(pizza, goodies);

            return RedirectToPage("../Index");
        }
    }
}