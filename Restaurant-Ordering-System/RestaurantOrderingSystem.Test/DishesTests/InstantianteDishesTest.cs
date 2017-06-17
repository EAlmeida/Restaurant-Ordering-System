using NUnit.Framework;
using RestaurantOrderingSystem.Entities;
using RestaurantOrderingSystem.Test.Fakes;

namespace RestaurantOrderingSystem.Test.DishesTests
{
    [TestFixture]
    public class InstantianteDishesTest
    {
        /*
         * TODO LIST:
         * 1) When I istantiate a dish, I should have the properties: Name, price and description [OK];
         * 2) Dishes should are distributed into 3 categories: 
         *      1.	Starter [OK];
         *      2.	Main Course [OK];
         *      3.	Desserts [OK];
         * 3) More categories could be added in future: [OK]
         */

        private Dish _dish;

        [Test]
        public void GivenIHaveADish_WhenIInstantiateThis_ThenIShouldHaveADishWithNamePriceAndDescription()
        {
            //arrange            

            //act
            _dish = new Starter { Name = "GreenSalad", Price = 15.00, Description = "This is health and green" };

            //assert
            Assert.IsNotNullOrEmpty(_dish.Name);
            Assert.IsNotNullOrEmpty(_dish.Description);
            Assert.IsTrue(_dish.Price > 0);
        }

        [Test]
        public void GivenIHaveAStarter_WhenIInstantiateThis_ThenIShouldHaveASpecificTypeStarter()
        {
            //arrange

            //act
            _dish = new Starter();

            //assert            
            Assert.AreEqual(typeof(Starter), _dish.GetType());
        }

        [Test]
        public void GivenIHaveAMainCourse_WhenIInstantiateThis_ThenIShouldHaveASpecificTypeMainCourse()
        {
            //arrange

            //act
            _dish = new MainCourse();

            //assert            
            Assert.AreEqual(typeof(MainCourse), _dish.GetType());
        }

        [Test]
        public void GivenIHaveADessert_WhenIInstantiateThis_ThenIShouldHaveASpecificCategoryDessert()
        {
            //arrange           

            //act
            _dish = new Dessert();

            //assert            
            Assert.AreEqual(typeof(Dessert), _dish.GetType());
        }

        [Test]
        public void GivenIHaveANewCategoryDish_WhenICreateThisNewOne_ThenIShouldHaveASpecificTypeNewCategoryDish()
        {
            //arrane

            //act
            _dish = new FakeNewCategoryDish { SpecificType = "foo" };

            //assert
            Assert.AreEqual(typeof(FakeNewCategoryDish), _dish.GetType());
        }
        
        [TearDown]
        public void TearDown()
        {
            _dish = null;
        }
    }
}
