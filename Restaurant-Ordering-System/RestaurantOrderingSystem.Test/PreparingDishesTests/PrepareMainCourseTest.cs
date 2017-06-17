using Moq;
using NUnit.Framework;
using RestaurantOrderingSystem.Business;
using RestaurantOrderingSystem.Common;
using RestaurantOrderingSystem.Entities;
using RestaurantOrderingSystem.Enums;

namespace RestaurantOrderingSystem.Test.PreparingDishesTests
{
    [TestFixture]
    public class PrepareMainCourseTest
    {
        /* TO DO LIST:
         * •Dish can be prepared by various options.                
                2.	Main course could be prepared bland or spicy [OK]                
           •There should be scope to add more options in future.
         */

        private MainCourse _mainCourse;
        private Mock<BaseOptionPrepare> _mockOptionPrepare;

        [SetUp]
        public void SetUp()
        {
            _mainCourse = new MainCourse { Id = 2, Name = "Filet Mignon", Price = 35.00, Description = "Delicious red meat" };
            _mockOptionPrepare = new Mock<BaseOptionPrepare>();
            _mockOptionPrepare.Setup(_ => _.IsOptionActive).Returns(true);            
        }

        [Test]
        public void GivenIHaveAMainCourse_WhenIPrepareIt_IShouldBeAbleToPrepareWithSpecifciOptionBland()
        {
            //arrange         
            _mockOptionPrepare.Setup(_ => _.OptionDescription).Returns(Utility.GetEnumDescription(OptionDishesTypes.PreparedBland));
            _mockOptionPrepare.Setup(_ => _.PrepareWithSpecificOptions()).Returns(OptionDishesTypes.PreparedBland);
            var prepareMainCourse = new BasePrepareDish(_mockOptionPrepare.Object, _mainCourse);

            //act
            var preparedDish = prepareMainCourse.Prepare();
            
            //assert            
            _mockOptionPrepare.Verify(_=>_.PrepareWithSpecificOptions(), Times.Once());
            Assert.AreEqual(OptionDishesTypes.PreparedBland, preparedDish.OptionPrepared);            
        }

        [Test]
        public void GivenIHaveAMainCourse_WhenIPrepareIt_IShouldBeAbleToPrepareWithSpecifciOptionSpicy()
        {
            //arrange         
            _mockOptionPrepare.Setup(_ => _.OptionDescription).Returns(Utility.GetEnumDescription(OptionDishesTypes.PreparedSpicy));
            _mockOptionPrepare.Setup(_ => _.PrepareWithSpecificOptions()).Returns(OptionDishesTypes.PreparedSpicy);
            var prepareMainCourse = new BasePrepareDish(_mockOptionPrepare.Object, _mainCourse);

            //act
            var preparedDish = prepareMainCourse.Prepare();

            //assert            
            _mockOptionPrepare.Verify(_ => _.PrepareWithSpecificOptions(), Times.Once());
            Assert.AreEqual(OptionDishesTypes.PreparedSpicy, preparedDish.OptionPrepared);
        }


        [TearDown]
        public void TearDown()
        {
            _mainCourse = null;
            _mockOptionPrepare = null;
        }
    }
}
