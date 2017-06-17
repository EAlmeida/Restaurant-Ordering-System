using RestaurantOrderingSystem.Interfaces;
using RestaurantOrderingSystem.Enums;

namespace RestaurantOrderingSystem.Business
{
    public abstract class BaseOptionPrepare : IOptionPrepare
    {
        //Due the need of Moq Framework, I had to use virtual.
        public virtual bool IsOptionActive { get; set; }
        public virtual string OptionDescription { get; set; }

        public abstract OptionDishesTypes PrepareWithSpecificOptions();
    }
}
