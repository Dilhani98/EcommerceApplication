﻿namespace Ecommerce.APi.Search.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
    }
}
