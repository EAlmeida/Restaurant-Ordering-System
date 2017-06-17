using System.Collections.Generic;
using RestaurantOrderingSystem.Entities;

namespace RestaurantOrderingSystem.Business
{
    public class Menu
    {
        public IList<Dish> Dishes { get; }

        public Menu(IList<Dish> dishes)
        {
            Dishes = dishes;
        }
        
    }
}
