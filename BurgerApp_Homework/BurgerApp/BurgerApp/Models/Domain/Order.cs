using BurgerApp.Models.Enums;

namespace BurgerApp.Models.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public bool IsDelivered { get; set; }
        public BurgerFlavour BurgerFlavour { get; set; }
        public string Location { get; set; }
    }
}
