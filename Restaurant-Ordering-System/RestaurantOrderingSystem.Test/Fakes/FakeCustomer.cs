using RestaurantOrderingSystem.Entities;
using RestaurantOrderingSystem.Enums;
using RestaurantOrderingSystem.Interfaces;

namespace RestaurantOrderingSystem.Test.Fakes
{
    public class FakeCustomer : ICustomer
    {
        public bool OrderDishIsCalled;

        public CustomerChoice OrderDish(Dish dish, OptionDishesTypes optionDishesTypes)
        {
            OrderDishIsCalled = true;

            var customerChoice = new CustomerChoice
            {
                Dish = dish,
                OptionDishesType = optionDishesTypes
            };

            return customerChoice;
        }
    }
}
