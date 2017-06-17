using RestaurantOrderingSystem.Enums;

namespace RestaurantOrderingSystem.Interfaces
{
    public interface IOptionPrepare
    {
        string OptionDescription { get; set; }
        OptionDishesTypes PrepareWithSpecificOptions();
        bool IsOptionActive { get; set; }
    }
}
