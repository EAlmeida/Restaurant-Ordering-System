using System.Collections.Generic;

namespace RestaurantOrderingSystem.Entities
{
    public class Order
    {
        public IList<CustomerChoice> CustomerChoices { get; set; }
        public int OrderNumber { get; set; }
        public Table Table { get; set; }
    }
}
