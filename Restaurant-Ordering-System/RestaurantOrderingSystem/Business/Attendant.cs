using System.Collections.Generic;
using RestaurantOrderingSystem.Entities;
using RestaurantOrderingSystem.Common;

namespace RestaurantOrderingSystem.Business
{
    public class Attendant
    {
        public Order CreateOrder(IList<CustomerChoice> customerChosen, Table table)
        {
            return new Order()
            {
                CustomerChoices = customerChosen,
                OrderNumber = Utility.IdentityFake(), //temporaryLogicNumberRequest      
                Table = table,
            };
        }

    }
}
