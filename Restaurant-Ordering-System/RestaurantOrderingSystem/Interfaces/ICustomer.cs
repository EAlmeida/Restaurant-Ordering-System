using RestaurantOrderingSystem.Entities;
using RestaurantOrderingSystem.Enums;

namespace RestaurantOrderingSystem.Interfaces
{
    public interface ICustomer
    {
        CustomerChoice OrderDish(Dish dish, OptionDishesTypes optionDishesTypes);
    }
}
