using SEDC.PizzaApp.Models.Enums;

namespace SEDC.PizzaApp.Models.ViewModels
{
    public class OrderDetailsViewModel
    {
        public string PizzaName { get; set; }
        public string UserFullName { get; set; }
        public int Price { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string UserAddress { get; set; }
    }
}
