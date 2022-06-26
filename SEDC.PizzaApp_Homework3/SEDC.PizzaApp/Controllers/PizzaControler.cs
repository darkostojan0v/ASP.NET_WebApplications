using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;
using SEDC.PizzaApp.Models.Mappers;

namespace SEDC.PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult GetPizzas()
        {

            List<PizzaDetailsViewModel> dbPizzas = StaticDb.Pizzas.Select(pizza => pizza.ToPizzaDetailsViewModel()).ToList();

            return View(dbPizzas);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }

            //Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);

            PizzaDetailsViewModel? pizza = StaticDb.Pizzas.Select(pizza => pizza.ToPizzaDetailsViewModel()).FirstOrDefault(x => x.Id == id);
            if (pizza == null)
            {
                //return RedirectToAction("Error");

                return View("ResourceNotFound");
            }

            return View(pizza);

        }

        public IActionResult Error()
        {
            return View();
        }

    }
}