using BurgerApp.Models.Domain;
using BurgerApp.Models.ViewModels;

namespace BurgerApp.Models.Mappers
{
    public static class BurgerMapper
    {
        public static BurgerViewModel ToBurgerViewModel(Burger burgerDb)
        {
            return new BurgerViewModel
            {
                Id = burgerDb.Id,
                Name = burgerDb.Name,
                Price = burgerDb.Price,
                IsVegetarian = burgerDb.IsVegetarian,
                IsVegan = burgerDb.IsVegan,
                HasFries = burgerDb.HasFries,
            };

        }
    }
}
