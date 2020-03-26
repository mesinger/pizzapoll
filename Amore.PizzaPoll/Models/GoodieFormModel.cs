using System.Collections.Generic;

namespace Amore.PizzaPoll.Models
{
    public class GoodieFormModel
    {
        public string PizzaId { get; set; }
        public Dictionary<string, bool> SelectedGoodies { get; } = new Dictionary<string, bool>() // goodieId -> isDefault, isSelected
        {
            {"anchovies", false},
            {"artichokes", false},
            {"aubergine", false},
            {"basil", false},
            {"blackolives", false},
            {"buffalomozzarella", false},
            {"capers", false},
            {"cocktailtomatoes", false},
            {"corn", false},
            {"fullgrain", false},
            {"garlic", false},
            {"ham", false},
            {"mozzarella", false},
            {"mushrooms", false},
            {"oliveoil", false},
            {"onion", false},
            {"oregano", false},
            {"parmesan", false},
            {"pepper", false},
            {"rawham", false},
            {"ricotta", false},
            {"rucola", false},
            {"spicysalami", false},
            {"tomatosauce", false},
            {"tuna", false},
            {"zucchini", false},
        };
    }
}