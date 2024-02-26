using Ecommerce.Api.Sales.Db;

namespace Ecommerce.Api.Sales.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerID { get; set; }

        public DateTime OrderDate { get; set; }

        public int Total { get; set; }

        public List<Orderitems> OrderItem { get; set; }
    }
}
