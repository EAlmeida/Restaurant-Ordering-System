using RestaurantOrderingSystem.Enums;

namespace RestaurantOrderingSystem.Business
{
    public class MainCourseOptionPrepare : BaseOptionPrepare
    {
        public OptionDishesTypes OptionMainCourseTypes;

        public override OptionDishesTypes PrepareWithSpecificOptions()
        {
            return OptionMainCourseTypes;
        }
    }
}
