using BurgerApp.Models.Domain;
using BurgerApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BurgerApp.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Is Delivered")]
        public bool IsDelivered { get; set; }
        [Display(Name = "Burger Flavour")]
        public BurgerFlavour BurgerFlavour { get; set; }
        [Display(Name = "Location")]
        public string Location { get; set; }
    }
}
