using RestaurantOrderingSystem.Entities;
using RestaurantOrderingSystem.Enums;
using RestaurantOrderingSystem.Interfaces;

namespace RestaurantOrderingSystem.Business
{  
    public class Customer : ICustomer
    {
        public CustomerChoice OrderDish(Dish dish, OptionDishesTypes optionDishesTypes)
        {
            var customerChoice = new CustomerChoice
            {
                Dish = dish,
                OptionDishesType = optionDishesTypes
            };

            return customerChoice;
        }
    }
}
