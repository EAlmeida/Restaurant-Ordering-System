using RestaurantOrderingSystem.Enums;
using RestaurantOrderingSystem.Common;

namespace RestaurantOrderingSystem.Entities
{
    public class CustomerChoice
    {        
        public CustomerChoice()
        {
            Id = Utility.IdentityFake();
        }
        public int Id { get; set; }
        public Dish Dish { get; set; }
        public OptionDishesTypes OptionDishesType { get; set; }
    }
}
