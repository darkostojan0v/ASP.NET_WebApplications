using System.ComponentModel.DataAnnotations;

namespace BurgerApp.Models.ViewModels
{
    public class BurgerViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Price")]
        public int Price { get; set; }
        [Display(Name = "Is Vegetarian")]
        public bool IsVegetarian { get; set; }
        [Display(Name = "Is Vegan")]
        public bool IsVegan { get; set; }
        [Display(Name = "Has Fries")]
        public bool HasFries { get; set; }
    }
}
