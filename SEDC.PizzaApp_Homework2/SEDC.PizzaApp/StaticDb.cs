using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Enums;

namespace SEDC.PizzaApp
{
    public static class StaticDb
    {
        public static List<Pizza> Pizzas = new List<Pizza>{
            new Pizza()
            {
                Id = 1,
                Name = "Capri",
                Price = 300,
                IsOnPromotion = true,
                PizzaSize = PizzaSize.Normal,
                HasExtras = false
                
            },
            new Pizza()
            {
                Id = 2,
                Name = "Pepperoni",
                Price = 400,
                IsOnPromotion = false,
                PizzaSize = PizzaSize.Family,
                HasExtras = true
            }
        };

        public static List<User> Users = new List<User>
        {
            new User()
            {
                Id = 1,
                FirstName = "Tanja",
                LastName = "Stojanovska",
                PhoneNumber = "531683681"
            },
            new User()
            {
                Id = 2,
                FirstName = "Stefan",
                LastName = "Trajkov",
                PhoneNumber = "62462164"
            }
        };

        public static List<Order> Orders = new List<Order>
        {
            new Order
            {
                Id = 1,
                PizzaId = 1,
                UserId = 2,
                Pizza = Pizzas.First(),
                User = Users.First(x => x.Id == 2),
                PaymentMethod = PaymentMethod.Cash

            },

             new Order
            {
                Id = 2,
                PizzaId = 1,
                UserId = 2,
                Pizza = Pizzas.First(x => x.Id == 2),
                User = Users.First(x => x.Id == 1),
                PaymentMethod = PaymentMethod.Card

            }
        };
    }
}
