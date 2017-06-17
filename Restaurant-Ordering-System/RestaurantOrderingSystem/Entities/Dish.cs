using System.Collections.Generic;
using System.Linq;
using RestaurantOrderingSystem.Enums;
using RestaurantOrderingSystem.Common;
using RestaurantOrderingSystem.Entities.Interfaces;

namespace RestaurantOrderingSystem.Entities
{
    public class Dish : IDish
    {
        public Dish()
        {
            OptionDishesTypes = Utility.GetValues<OptionDishesTypes>().ToList();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }        
        public IList<OptionDishesTypes> OptionDishesTypes;
    }
}
