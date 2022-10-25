// C# program to print the greatest numbers in an array
// using WHERE Clause LINQ
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace LinqAssignment
{
    class Program
    {

        static void Main(string[] args)
        {

            //Tennis Players
            List<TennisPlayer> players = TennisPlayer.GetTennisPlayer();


            //Orders
            List<Order> orders = Order.GetOrders();


            //Items
            List<Item> items = Item.GetItems();



            // Array of numbers
            int[] Numbers = { 4, 6, 15, 20, 17, 7,
                    9, 45, 8 };

            // numbers greater than 100 and less than 1000
            var requiredNumbers = from n in Numbers
                                  where n * n * n > 100 && n * n * n < 1000
                                  select n;
            Console.WriteLine("Cubes that are greater than 100 and less than 1000 are :");

            // Get the greater numbers
            foreach (var s in requiredNumbers)
            {
                Console.WriteLine($"Number: {s}, Cube: {s * s * s}");
            }

            //Count and display even numbers
            var evenNumbers = from n in Numbers
                              where n % 2 == 0
                              select n;
            var count = 0;

            Console.WriteLine();
            Console.WriteLine("Even Numbers in the array");

            foreach (var s in evenNumbers)
            {
                Console.WriteLine(s);
                count++;
            }

            Console.WriteLine($"Total even numbers: {count}");





            //Check if all the quantities in order > 0

            Console.WriteLine();
            bool isGreaterThanZero = true;
            isGreaterThanZero = orders.All(x => x.Quantity > 0);
            if (isGreaterThanZero)
            {
                Console.WriteLine("All the quantities in order are greater than 0.");
            }
            else
            {
                Console.WriteLine("All the quantities in order are not greater than 0.");
            }



            //Orders place before Jan of this year?

            Console.WriteLine();

            bool placedBeforeJan = false;
            placedBeforeJan = orders.All(x => x.OrderDate < new DateTime(2022, 01, 01));
            if (placedBeforeJan)
            {
                Console.WriteLine("Some orders are placed before Jan, 2022");
            }
            else
            {
                Console.WriteLine("Orders are not placed before Jan, 2022.");
            }




            //Display Order by descending order of date

            Console.WriteLine();
            Console.WriteLine("Display Order by descending date");

            IEnumerable<Order> orderByDate = orders.OrderByDescending(o => o.OrderDate);
            foreach (var o in orderByDate)
                Console.WriteLine($"Id: {o.OrderId}, Name: {o.ItemName}, Date: {o.OrderDate}, Quantity: {o.Quantity}");


            //Display order by descending order of quantity

            Console.WriteLine();
            Console.WriteLine("Display Order by descending quantity");

            var orderByQuantity = orders.OrderByDescending(o => o.Quantity);
            foreach (var o in orderByQuantity)
                Console.WriteLine($"Id: {o.OrderId}, Name: {o.ItemName}, Date: {o.OrderDate}, Quantity: {o.Quantity}");

            Console.WriteLine();
            Console.WriteLine($"Order with largest Quantity in a single order: ");
            Console.WriteLine($"Id: {orderByQuantity.ElementAt(0).OrderId}, Name: {orderByQuantity.ElementAt(0).ItemName}, Date: {orderByQuantity.ElementAt(0).OrderDate}, Quantity: {orderByQuantity.ElementAt(0).Quantity}");



            //Display order grouped by month in the descending order of the order date

            Console.WriteLine();
            Console.WriteLine("Display Order grouped by the month in the descending order of the order date");


            var orderByMonth = orders.GroupBy(o => o.OrderDate.Month).OrderByDescending(s => s.Count());
            foreach (var od in orderByMonth)
            {
                Console.WriteLine($"Month: {od.Key}, Count: {od.Count()}");
                foreach (var o in od)
                {
                    Console.WriteLine($"Id: {o.OrderId}, Name: {o.ItemName}, Date: {o.OrderDate}, Quantity: {o.Quantity}");
                }
            }



            //Sum of quantities of each item and max quantity item

            Console.WriteLine();
            Console.WriteLine("Sum of quantities of each item");
            var orderGroupedByItem = orders.GroupBy(o => o.ItemName);
            var maxQuantityItem = orderGroupedByItem.ElementAt(0);
            var maxQuantity = 0;
            foreach (var o in orderGroupedByItem)
            {
                var itemQuantity = o.Sum(x => x.Quantity);
                Console.WriteLine($"Item: {o.Key}, Sum of quantities: {itemQuantity}");
                if (itemQuantity > maxQuantity)
                {
                    maxQuantity = itemQuantity;
                    maxQuantityItem = o;
                }

            }


            Console.WriteLine();
            Console.WriteLine($"Item with maximum orders (quantity): {maxQuantityItem.Key}, Quantity ordered: {maxQuantity}");



            //Display with Item price

            Console.WriteLine();
            Console.WriteLine("Display Order with total price, grouped by the month in the descending order of the order date");

            var order = orders.Join(items,
                orders => orders.ItemName,
                items => items.ItemName,
                (o, i) => new
                {
                    OrderId = o.OrderId,
                    ItemName = o.ItemName,
                    OrderDate = o.OrderDate,
                    TotalPrice = i.ItemPrice * o.Quantity,
                    OrderQuantity = o.Quantity
                });
            var orderGroupedByMonth = order.GroupBy(o => o.OrderDate.Month).OrderByDescending(s => s.Count());

            foreach (var o in orderGroupedByMonth)
            {
                var decreaseByDate = o.OrderByDescending(o => o.OrderDate);
                foreach (var ord in decreaseByDate)
                    Console.WriteLine($"OrderId: {ord.OrderId}, Item Name: {ord.ItemName}, Date: {ord.OrderDate}, Toatl Price: {ord.TotalPrice}");
            }




            //Split tennis players into two teams and make possible combination of matches

            Console.WriteLine();
            Console.WriteLine("Split tennis players into two teams and make possible combination of matches");

            List<List<TennisPlayer>> playerLists = players
        .Select((x, i) => new { Index = i, Value = x })
        .GroupBy(x => x.Index / 7)
        .Select(x => x.Select(v => v.Value).ToList())
        .ToList();


            var combinationOfPlayers = from first in playerLists[0]
                      from second in playerLists[1]
                      select new
                      {
                          Player1 = first.Name,
                          Player2 = second.Name,
                          Country1 = first.Country,
                          Country2 = second.Country
                      };

            foreach(var player in combinationOfPlayers)
            {
                if(player.Country1 != player.Country2)
                {
                    Console.WriteLine($"Player1: {player.Player1}, Country: {player.Country1}, Player2: {player.Player2}, Country: {player.Country2}");
                }
            }

                  



        }
    }
}