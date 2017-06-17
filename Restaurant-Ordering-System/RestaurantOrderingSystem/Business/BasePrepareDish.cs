using RestaurantOrderingSystem.Entities;
using RestaurantOrderingSystem.Interfaces;

namespace RestaurantOrderingSystem.Business
{
    public class BasePrepareDish : IPrepareDish
    {
        private readonly IOptionPrepare _optionPrepare;
        private readonly Dish _dish;

        public BasePrepareDish(IOptionPrepare prepareOption, Dish dish)
        {
            _optionPrepare = prepareOption;
            _dish = dish;
        }

        public PreparedDish Prepare()
        {
            var preparedDish = new PreparedDish
            {
                Dish = _dish,
                IsPrepared = true,
                //TODO implement time
            };

            if (_optionPrepare.IsOptionActive)
                preparedDish.OptionPrepared = _optionPrepare.PrepareWithSpecificOptions();

            return preparedDish;
        }
    }
}
