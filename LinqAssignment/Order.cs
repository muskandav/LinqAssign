using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAssignment
{
    internal class Order
    {
        public int OrderId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }

        public Order(int orderId, string itemName, int quantity, DateTime orderDate)
        {
            OrderId = orderId;
            ItemName = itemName;
            Quantity = quantity;
            OrderDate = orderDate;
        }

        public static List<Order> GetOrders()
        {
            return new List<Order>()
            {
                new Order(1, "Book", 10, new DateTime(2022, 12, 5)),
            new Order(2, "Ball", 20, new DateTime(2022, 11, 20)),
            new Order(3, "Tshirt", 5, new DateTime(2022, 10, 25)),
            new Order(4, "Book", 15, new DateTime(2022, 12, 25)),
            new Order(5, "Ball", 12, new DateTime(2022, 10, 15)),
            new Order(6, "Ball", 9, new DateTime(2022, 11, 5)),
            new Order(7, "Tshirt", 10, new DateTime(2022, 12, 13)),
        };
        }
    }

}
