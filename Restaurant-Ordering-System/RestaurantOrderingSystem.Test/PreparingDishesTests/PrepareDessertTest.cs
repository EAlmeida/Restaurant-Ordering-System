using NUnit.Framework;
using Moq;
using RestaurantOrderingSystem.Entities;
using RestaurantOrderingSystem.Business;
using RestaurantOrderingSystem.Enums;
using RestaurantOrderingSystem.Common;

namespace RestaurantOrderingSystem.Test.PreparingDishesTests
{
    [TestFixture]
    public class PrepareDessertTest
    {
        /* TO DO LIST:
            •Dish can be prepared by various options.                         
              3.	Dessert could be with or without sugar [OK]
            •There should be scope to add more options in future.  */

        private Dessert _dessert;
        Mock<BaseOptionPrepare> _mockOptionPrepare;

        [SetUp]
        public void SetUp()
        {
            _dessert = new Dessert { Id = 3, Name = "Petit Gateau", Price = 20.99, Description = "Small chocolate cake with crispy shell and creamy filling served usually accompanied by ice cream" };
            _mockOptionPrepare = new Mock<BaseOptionPrepare>();
            _mockOptionPrepare.Setup(_ => _.IsOptionActive).Returns(true);
        }

        [Test]
        public void GivenIHaveADessert_WhenIPrepareIt_IShouldBeAbleToPrepareWithSugar()
        {
            //assert                        
            _mockOptionPrepare.Setup(_ => _.OptionDescription).Returns(Utility.GetEnumDescription(OptionDishesTypes.WithSugar));
            _mockOptionPrepare.Setup(_ => _.PrepareWithSpecificOptions()).Returns(OptionDishesTypes.WithSugar);
            var prepareDish = new BasePrepareDish(_mockOptionPrepare.Object, _dessert);

            //act
            var result = prepareDish.Prepare();

            //arrange            
            _mockOptionPrepare.Verify(_ => _.PrepareWithSpecificOptions(), Times.AtLeastOnce);
            Assert.AreEqual(OptionDishesTypes.WithSugar, result.OptionPrepared);
        }

        [Test]
        public void GivenIHaveADessert_WhenIPrepareIt_IShouldBeAbleToPrepareWithoutSugar()
        {
            //assert     
            _mockOptionPrepare.Setup(_ => _.OptionDescription).Returns(Utility.GetEnumDescription(OptionDishesTypes.WithoutSugar));
            _mockOptionPrepare.Setup(_ => _.PrepareWithSpecificOptions()).Returns(OptionDishesTypes.WithoutSugar);
            var prepareDish = new BasePrepareDish(_mockOptionPrepare.Object, _dessert);

            //act
            var result = prepareDish.Prepare();

            //arrange
            _mockOptionPrepare.Verify(_ => _.PrepareWithSpecificOptions(), Times.AtLeastOnce);
            Assert.AreEqual(OptionDishesTypes.WithoutSugar, result.OptionPrepared);
        }

        [TearDown]
        public void TearDown()
        {
            _dessert = null;
            _mockOptionPrepare = null;
        }
    }
}
