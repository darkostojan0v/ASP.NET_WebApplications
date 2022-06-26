using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Models.Mappers
{
    public static class PizzaMapper
    {

        public static PizzaDetailsViewModel ToPizzaDetailsViewModel(Pizza dbPizza)
        {
            return new PizzaDetailsViewModel
            {
                Id = dbPizza.Id,
                Name = dbPizza.Name,
                Price = PizzaPrice(dbPizza),
                PizzaSize = dbPizza.PizzaSize
            };
        }

        public static decimal PizzaPrice(Pizza pizza)
        {
            if (pizza.HasExtras)
            {
                return pizza.Price + 10;
            }
            else return pizza.Price;
        }
    }
}
