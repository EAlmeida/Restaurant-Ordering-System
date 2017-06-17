using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RestaurantOrderingSystem.Business;
using RestaurantOrderingSystem.Entities;
using RestaurantOrderingSystem.Enums;
using RestaurantOrderingSystem.Test.Fakes;


namespace RestaurantOrderingSystem.Test
{
    [TestFixture]
    public class OrdersTests
    {
        /* TO DO LIST:
         * • Attendant should be able to create order which consists of dishes with options chosen by customer for each dish. 
         * Order will also have associated table number.
         * 
         * 1) Attendante should create order which consists of dishes [OK]
         * 2) These dishes should be with options chosen by customer for each dish [OK]
         * 3) The order shoulb be: number, DishesList, TableNumber, OptionsChosen [OK]
         */

        private FakeCustomer _customer;
        private IList<CustomerChoice> _choices;
        private Table _table;
        private Order _order;

        [SetUp]
        public void SetUp()
        {
            _customer = new FakeCustomer();
            _choices = new List<CustomerChoice>();
            _table = new Table { TableNumber = 9 };

            var dish = new Starter { Id = 1, Name = "GreenSalad", Price = 15.00, Description = "This is health and green" };
            var option = OptionDishesTypes.WithLessSalt;

            var dish2 = new MainCourse { Id = 2, Name = "Filet Mignon", Price = 35.00, Description = "Delicious red meat" };
            var option2 = OptionDishesTypes.PreparedSpicy;

            var customerChoice = _customer.OrderDish(dish, option);
            _choices.Add(customerChoice);

            var customerChoice2 = _customer.OrderDish(dish2, option2);
            _choices.Add(customerChoice2);
        }

        [Test]
        public void GivenIHaveAnAttendant_WhenTheAttendatCreateAnOrder_ThenIShouldHaveAnOrderWichConsistsOfDishes()
        {
            //arrange
            var attendant = new Attendant();            

            //act
            _order = attendant.CreateOrder(_choices, _table);

            //assert
            Assert.IsNotNull(_order.CustomerChoices);
        }

        [Test]
        public void GivenIHaveAnAttendant_WhenTheAttendantCreateAnOrder_ThenIShouldHaveAnOrderWithDishesOptionChosenByCustomerForEachDish()
        {
            //arrange            
            var attendant = new Attendant();

            //act
            _order = attendant.CreateOrder(_choices, _table);

            var expected = _order.CustomerChoices.Where(_ => _.Id > 0).Select(_ => _.OptionDishesType);

            //assert
            Assert.IsNotNull(expected);
            Assert.IsNotEmpty(expected);
            Assert.AreEqual(_order.CustomerChoices, _choices);
            Assert.IsTrue(_customer.OrderDishIsCalled);
        }

        [Test]
        public void GivenIHaveAnAttendant_WhenTheAttendantCreateAnOrder_ThenIShouldHaveAnOrderWithNumberOrder()
        {
            //arrange            
            var attendant = new Attendant();

            //act
            _order = attendant.CreateOrder(_choices, _table);

            //assert
            Assert.IsNotNull(_order.OrderNumber);
        }

        [Test]
        public void GivenIHaveAnAttendant_WhenTheAttendantCreateAnOrder_ThenIShouldHaveAnOrderWithDishesList()
        {
            //arrange            
            var attendant = new Attendant();

            //act
            _order = attendant.CreateOrder(_choices, _table);

            var dishe = _order.CustomerChoices.Where(_ => _.Id > 0).Select(_ => _.Dish).FirstOrDefault();

            //assert
            Assert.IsNotNull(dishe);
        }

        [Test]
        public void GivenIHaveAnAttendant_WhenTheAttendantCreateAnOrder_ThenIShouldHaveAnOrderWithTableNumber()
        {
            //arrange            
            var attendant = new Attendant();

            //act
            _order = attendant.CreateOrder(_choices, _table);

            //assert
            Assert.IsTrue(_order.Table.TableNumber > 0);
            Assert.IsNotNull(_order.Table);
        }

        [Test]
        public void GivenIHaveAnAttendant_WhenTheAttendantCreateAnOrder_ThenIShouldHaveAnOrderWithOptionsChosen()
        {
            //arrange            
            var attendant = new Attendant();

            //act
            _order = attendant.CreateOrder(_choices, _table);

            var optionDishe = _order.CustomerChoices.Where(_ => _.Id > 0).Select(_ => _.OptionDishesType).FirstOrDefault();

            //assert
            Assert.IsNotNull(optionDishe);
        }

        [TearDown]
        public void TearDown()
        {
            _choices = null;
            _customer = null;
        }
    }
}
