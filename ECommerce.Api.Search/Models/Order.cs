namespace Ecommerce.APi.Search.Models
{
    public class Order
    {
         
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int Total { get; set; }

        public List<OrderItem> OrderItem { get; set; }
    }

}
