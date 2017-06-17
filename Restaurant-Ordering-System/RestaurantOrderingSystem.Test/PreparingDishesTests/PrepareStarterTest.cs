using NUnit.Framework;
using RestaurantOrderingSystem.Business;
using RestaurantOrderingSystem.Entities;
using RestaurantOrderingSystem.Enums;
using RestaurantOrderingSystem.Test.Fakes;

namespace RestaurantOrderingSystem.Test.PreparingDishesTests
{
    [TestFixture]
    public class PrepareStarterTest
    {
        /* TO DO LIST:
         * •Dish can be prepared by various options.
                1.	Starter could be prepared either with less or normal salt [OK];                
           •There should be scope to add more options in future.
         */

        private Dish _starter;
        private FakeStarterPrepareOption _fakePrepareOption;

        [SetUp]
        public void SetUp()
        {
            _starter = new Starter { Id = 1, Name = "GreenSalad", Price = 15.00, Description = "This is health and green" };
            _fakePrepareOption = new FakeStarterPrepareOption() { IsOptionActive = true};
        }

        [Test]
        public void GivenIHaveAStarter_WhenIPrepareIt_IShouldBeAbleToPrepareWithASpecificRecipeWithLessSalt()
        {
            //arrange            
            _fakePrepareOption.OptionStarterType = OptionDishesTypes.WithLessSalt;
            var prepareStarter = new BasePrepareDish(_fakePrepareOption, _starter);            

            //act            
            var dish = prepareStarter.Prepare();

            //assert
            Assert.IsTrue(_fakePrepareOption.PrepareWithSpecificOptionsIsCalled);
            Assert.AreEqual(OptionDishesTypes.WithLessSalt, dish.OptionPrepared);
        }

        [Test]
        public void GivenIHaveAStarter_WhenIPrepareIt_IShouldBeAbleToPrepareWithASpecificOptionNormalSalt()
        {
            //arrange
            _fakePrepareOption.OptionStarterType = OptionDishesTypes.NormalSalt;
            var prepareStarter = new BasePrepareDish(_fakePrepareOption, _starter);

            //act            
            var preparedDish = prepareStarter.Prepare();

            //assert
            Assert.IsTrue(_fakePrepareOption.PrepareWithSpecificOptionsIsCalled);
            Assert.AreEqual(OptionDishesTypes.NormalSalt, preparedDish.OptionPrepared);
        }
        
        [TearDown]
        public void TearDown()
        {
            _starter = null;
            _fakePrepareOption = null;
        }
    }
}
