using RestaurantOrderingSystem.Enums;

namespace RestaurantOrderingSystem.Business
{
    public class StarterOptionPrepare : BaseOptionPrepare
    {
        public OptionDishesTypes OptionStarterType;

        public override OptionDishesTypes PrepareWithSpecificOptions()
        {
            return OptionStarterType;
        }
    }

}
