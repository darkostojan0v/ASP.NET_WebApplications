using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Mappers;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class PizzaController : Controller
    {

        public IActionResult GetPizzas()
        {
            List<Pizza> dbPizzas = StaticDb.Pizzas;

            List<PizzaDetailsViewModel> pizzaViewModels = dbPizzas.Select(x => PizzaMapper.ToPizzaDetailsViewModel(x)).ToList();

            return View(pizzaViewModels);

            //return View(dbPizzas);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new EmptyResult();
            }

            Pizza dbPizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
            if (dbPizza == null)
            {
                return new EmptyResult();
            }
            
            PizzaDetailsViewModel pizzaDetailsViewModel = PizzaMapper.ToPizzaDetailsViewModel(dbPizza);

            return View(pizzaDetailsViewModel);
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}