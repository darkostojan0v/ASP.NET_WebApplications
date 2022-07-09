using BurgerApp.Models.Domain;
using BurgerApp.Models.ViewModels;

namespace BurgerApp.Models.Mappers
{
    public static class OrderMapper
    {
        public static OrderViewModel ToOrderViewModel(Order orderDb)
        {
            return new OrderViewModel
            {
                Id = orderDb.Id,
                FullName = orderDb.FullName,
                Address = orderDb.Address,
                IsDelivered = orderDb.IsDelivered,
                BurgerFlavour = orderDb.BurgerFlavour,
                Location = orderDb.Location
            };
        }
    }
}
