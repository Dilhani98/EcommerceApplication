namespace Ecommerce.Api.Sales.Models
{
    public class Orderitems
    {

        public int Id { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
    }
}
