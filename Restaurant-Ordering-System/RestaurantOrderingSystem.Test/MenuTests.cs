using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RestaurantOrderingSystem.Entities;
using RestaurantOrderingSystem.Business;

namespace RestaurantOrderingSystem.Test
{
    [TestFixture]
    public class MenuTests
    {
        /*
         * TO DO LIST: Menu consists of all dishes served by the restaurant 
         * When the Menu is initialized, all dishes must be populated. [OK]
         * The Menu should be show the Dishes's options [OK]
         */

        [Test]
        public void GivenIHaveDishes_WhenIInstantiateMyMenu_ThenIShouldPopulateMyMenuWithThem()
        {
            //arrange
            IList<Dish> dishes = new List<Dish>{ 
                new Starter{Id = 1, Name = "GreenSalad", Price = 15.00, Description = "This is health and green"},
                new MainCourse{Id = 2, Name = "Filet Mignon", Price = 35.00, Description = "Delicious red meat"},
                new Dessert{Id = 3, Name = "Petit Gateau", Price = 20.99, Description = "Small chocolate cake with crispy shell and creamy filling served usually accompanied by ice cream"},
            };

            //act
            var menu = new Menu(dishes);

            //assert          
            Assert.IsNotNull(menu.Dishes);
        }

        [Test]
        public void GivenIHaveStarters_WhenIIntantiateTheMenu_ThenIShouldShowTheOptionsOfPrepareToIt()
        {
            //arrange            
            IList<Dish> dishes = new List<Dish>{ 
                new Starter(){Id = 1, Name = "Green salad", Price = 15.00, Description = "This is health and green"},                                
            };

            //act            
            var menu = new Menu(dishes);
                       
            var result = menu.Dishes.FirstOrDefault(_ => _.Id == 1)?.OptionDishesTypes;

            //assert            
            Assert.IsNotNull(result);            
        }

        [Test]
        public void GivenIHaveMainCourses_WhenIIntantiateTheMenu_ThenIShouldShowTheOptionsOfPrepareToIt()
        {
            //arrange            
            var mainCourseId = 2;

            var dishes = new List<Dish>{                 
                new MainCourse {Id = mainCourseId, Name = "Filet Mignon", Price = 35.00, Description = "Delicious red meat"},                
            };

            //act            
            var menu = new Menu(dishes);
            
            var result = menu.Dishes.FirstOrDefault(_ => _.Id == mainCourseId)?.OptionDishesTypes;
            
            //assert            
            Assert.IsNotNull(result);
        }

        [Test]
        public void GivenIHaveDesserts_WhenIIntantiateTheMenu_ThenIShouldShowTheOptionsOfPrepareToIt()
        {
            //arrange            
            IList<Dish> dishes = new List<Dish>{                 
                new Dessert(){Id = 3, Name = "Petit Gateau", Price = 20.99, Description = "Small chocolate cake with crispy shell and creamy filling served usually accompanied by ice cream"},
            };

            //act            
            var menu = new Menu(dishes);

            var desserts = dishes.FirstOrDefault(_ => _.GetType() == typeof(Dessert));
            var result = (Dessert)desserts;
                        
            //assert            
            if (result != null) Assert.IsNotNull(result.OptionDishesTypes);
        }

    }
}
