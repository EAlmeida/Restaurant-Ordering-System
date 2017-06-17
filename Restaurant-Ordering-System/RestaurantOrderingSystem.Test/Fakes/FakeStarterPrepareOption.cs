using RestaurantOrderingSystem.Business;
using RestaurantOrderingSystem.Enums;

namespace RestaurantOrderingSystem.Test.Fakes
{
    public class FakeStarterPrepareOption : BaseOptionPrepare
    {
        public bool PrepareWithSpecificOptionsIsCalled;
        public OptionDishesTypes OptionStarterType;

        public override OptionDishesTypes PrepareWithSpecificOptions()
        {
            PrepareWithSpecificOptionsIsCalled = true;

            return OptionStarterType;
        }
    }
}
