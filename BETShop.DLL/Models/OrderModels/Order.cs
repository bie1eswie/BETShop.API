using BETShop.API.Models;
using System;
using System.Collections.Generic;

namespace BETShop.API.Models.OrderModels
{
    public class Order : BaseModel
    {
        public Order()
        {
        }

        public Order(IReadOnlyList<OrderItem> orderItems, string user, decimal subtotal)
        {
            OrderItems = orderItems;
            UserID = user;
            Subtotal = subtotal;
        }

        public string UserID { get; set; }
        public DateTimeOffset OrderDate { get; set; } =  DateTimeOffset.Now;
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public decimal Subtotal { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
    }
}