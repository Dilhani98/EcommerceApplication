namespace Ecommerce.Api.Sales.Db
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderID { get; set; }

        public int ProductID { get; set; }
        public int Quantity { get; set; } 
        public int UnitPrice { get; set; }

    }
}
