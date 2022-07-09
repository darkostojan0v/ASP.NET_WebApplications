using BurgerApp.Models.Domain;
using BurgerApp.Models.Enums;

namespace BurgerApp
{
    public static class StaticDb
    {
        public static int OrderId = 2;
        public static int BurgerId = 3;
        public static List<Burger> Burgers = new List<Burger>
        {
            new Burger()
            {
                Id = 1,
                Name = "Hamburger",
                Price = 200,
                IsVegetarian = false,
                IsVegan = false,
                HasFries = true
            },
            new Burger()
            {
                Id = 2,
                Name = "Cheeseburger",
                Price = 180,
                IsVegetarian = false,
                IsVegan = false,
                HasFries = true
            },
            new Burger()
            {
                Id = 3,
                Name = "Veggieburger",
                Price = 165,
                IsVegetarian = true,
                IsVegan = true,
                HasFries = false
            }
        };

        public static List<Order> Orders = new List<Order>
        {
            new Order()
            {
                Id = 1,
                FullName = "'Sticky Fingers'",
                Address = "StreetOne",
                IsDelivered = true,
                BurgerFlavour = BurgerFlavour.Hamburger,
                Location = "Centar"
            },
            new Order()
            {
                Id = 2,
                FullName = "'The Cheesiest'",
                Address = "StreetTwo",
                IsDelivered = false,
                BurgerFlavour = BurgerFlavour.Cheeseburger,
                Location = "Karpos"
            }
        };
    }
}
