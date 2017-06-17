using System.ComponentModel;

namespace RestaurantOrderingSystem.Enums
{
    public enum OptionDishesTypes
    {
        [Description("Regular")]
        Regular = 0,

        [Description("With Less Salt")]
        WithLessSalt = 1,

        [Description("Normal Salt")]
        NormalSalt = 2,

        [Description("Prepared Bland")]
        PreparedBland = 3,

        [Description("Prepared Spicy")]
        PreparedSpicy = 4,

        [Description("With sugar")]
        WithSugar = 5,

        [Description("Without sugar")]
        WithoutSugar = 6,
    }
}
