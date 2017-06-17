using RestaurantOrderingSystem.Common;

namespace RestaurantOrderingSystem.Entities
{
    public class Table
    {
        public Table()
        {
            Id = Utility.IdentityFake();
        }

        public int Id { get; set; }
        public int TableNumber { get; set; }
    }
}
