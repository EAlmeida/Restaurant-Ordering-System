using RestaurantOrderingSystem.Enums;

namespace RestaurantOrderingSystem.Business
{
    public class DessertOptionPrepare : BaseOptionPrepare
    {
        public OptionDishesTypes OptionDessertTypes;

        public override OptionDishesTypes PrepareWithSpecificOptions()
        {
            return OptionDessertTypes;            
        }
    }
}
