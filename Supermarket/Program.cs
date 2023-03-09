namespace Supermarket
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var items = new List<Item>()
            {
                new Item()
                {
                   Name = "A",
                   Price=50,
                   SpecialPrice=130,
                   SpecialQuantity=3,
                },
                new Item()
                {
                    Name = "B",
                    Price=30,
                    SpecialPrice=45,
                    SpecialQuantity=2,
                },
                new Item()
                {
                    Name = "C",
                    Price=20,
                    SpecialPrice=0,
                    SpecialQuantity=0,
                },
                new Item()
                {
                    Name = "D",
                    Price=15,
                    SpecialPrice=0,
                    SpecialQuantity=0,
                }
            };

            var cart = new List<CartItem>();

            string input;

            foreach (var item in items)
            {
                Console.WriteLine($"Add product {item.Name} to cart");
            }
            Console.WriteLine("Checkout & print receipt");
            Console.WriteLine("Quit");

            do
            {
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please input something");
                    continue;
                }
                if (input.ToLower() == "checkout")
                {
                    CalculateTotal(cart);
                    break;
                }
                if (input != "checkout" && input != "quit")
                {
                    AddItemToCart(input.ToUpper(), items, cart);
                }
            }
            while (input.ToLower() != "quit");
        }

        private static void CalculateTotal(List<CartItem> cart)
        {
            var totalPrice = 0.0;
            foreach (var cartItem in cart)
            {
                double itemCalculatedPrice;
                if (cartItem.Item.SpecialQuantity > 0)
                {
                    itemCalculatedPrice = cartItem.Quantity / cartItem.Item.SpecialQuantity * cartItem.Item.SpecialPrice + cartItem.Quantity % cartItem.Item.SpecialQuantity * cartItem.Item.Price;
                }
                else
                {
                    itemCalculatedPrice = cartItem.Quantity * cartItem.Item.Price;
                }
                totalPrice += itemCalculatedPrice;
                Console.WriteLine("Item" + " " + "Quantity" + " " + "Subtotal" + " " + "Total");
                Console.WriteLine(cartItem.Item.Name + " " + cartItem.Quantity + " " + itemCalculatedPrice + " " + totalPrice);
                itemCalculatedPrice = 0.0;
            }
        }

       private static void AddItemToCart(string input, List<Item>? items, List<CartItem> cart)
        {
            foreach (var item in items)
            {
                if (item.Name == input)
                {
                    foreach (var cartItem in cart)
                    {
                        if (cartItem.Item.Name == input)
                        {
                            cartItem.Quantity++;
                            return;
                        }
                    }
                    cart.Add(new CartItem { Item = item, Quantity = 1 });
                    return;
                }
            }
            Console.WriteLine("Invalid input");
        }
    }

}