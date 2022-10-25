using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAssignment
{
    internal class Item
    {
        public string ItemName;
        public float ItemPrice;

        public Item(string itemName, float itemPrice)
        {
            ItemName = itemName;
            ItemPrice = itemPrice;
        }

        public static List<Item> GetItems()
        {
            return new List<Item>()
            {
                new Item("Book", 75),
                new Item("Ball", 10),
                new Item("Tshirt", 50)

            };
        }
    }
}

