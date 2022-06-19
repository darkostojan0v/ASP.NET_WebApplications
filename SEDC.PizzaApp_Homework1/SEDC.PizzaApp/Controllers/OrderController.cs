using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models;

namespace SEDC.PizzaApp.Controllers
{
    public class OrderController : Controller
    {

        [Route("ListOrders")]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new EmptyResult();
            }
            else
            {
                return View();
            }
        }

        public IActionResult JsonData()
        {
            Pizzerias pizzeria = new Pizzerias()
            {
                Id = 1,
                Name = "Jakomo"
            };

            return new JsonResult(pizzeria);
        }

        public IActionResult Redirect()
        {
            return RedirectToAction("Index");
        }
    }
}
