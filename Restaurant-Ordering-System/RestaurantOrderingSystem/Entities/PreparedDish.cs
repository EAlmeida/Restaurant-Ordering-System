using RestaurantOrderingSystem.Enums;

namespace RestaurantOrderingSystem.Entities
{
    public class PreparedDish
    {
        public Dish Dish { get; set; }
        public bool IsPrepared { get; set; }
        public OptionDishesTypes OptionPrepared { get; set; }
    }
}
