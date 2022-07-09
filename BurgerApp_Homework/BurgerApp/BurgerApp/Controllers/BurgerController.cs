using BurgerApp.Models.Domain;
using BurgerApp.Models.Mappers;
using BurgerApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.Controllers
{
    public class BurgerController : Controller
    {
        public IActionResult Index()
        {
            List<Burger> burgerDb = StaticDb.Burgers;

            List<BurgerViewModel> burgerViewModels = burgerDb.Select(x => BurgerMapper.ToBurgerViewModel(x)).ToList();

            ViewData["Title"] = "House Specials";

            return View(burgerViewModels);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("ResourceNotFound");
            }

            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(x => x.Id == id);

            if (burgerDb == null)
            {
                return View("ResourceNotFound");
            }

            BurgerViewModel burgerViewModel = BurgerMapper.ToBurgerViewModel(burgerDb);

            ViewData["Title"] = "Details for the choosen one:";
            return View(burgerViewModel);
        }

        public IActionResult MakeBurger()
        {
            BurgerViewModel burgerViewModel = new BurgerViewModel();
            ViewBag.Burgers = StaticDb.Burgers.Select(b => new BurgerViewModel
            {

                Name = b.Name
            });

            return View(burgerViewModel);
        }

        [HttpPost]
        public IActionResult MakeBurgerPost(BurgerViewModel burgerViewModel)
        {

            Burger newBurger = new Burger()
            {
                Id = StaticDb.BurgerId + 1,
                Name = burgerViewModel.Name,
                Price =burgerViewModel.Price,
                IsVegetarian = burgerViewModel.IsVegetarian,
                IsVegan = burgerViewModel.IsVegan,
                HasFries = burgerViewModel.HasFries
               
            };

            ViewBag.Burgers = StaticDb.Burgers.Select(b => new BurgerViewModel
            {

                Name = b.Name
            });

            StaticDb.Burgers.Add(newBurger);
            StaticDb.BurgerId++;
            return RedirectToAction("Index");

        }

        public IActionResult EditBurger(int? id)
        {
            if (id == null)
            {
                return View("ResourceNotFound");
            }

            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(x => x.Id == id);
            if (burgerDb == null)
            {
                return View("ResourceNotFound");
            }

            ViewBag.Burgers = StaticDb.Burgers.Select(x => new BurgerViewModel
            {
                Name = x.Name,
            });
            BurgerViewModel burgerViewModel = BurgerMapper.ToBurgerViewModel(burgerDb);

            return View(burgerViewModel);
        }

        [HttpPost]
        public IActionResult EditBurgerPost(BurgerViewModel burgerViewModel)
        {

            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(x => x.Id == burgerViewModel.Id);
            if (burgerDb == null)
            {
                return View("ResourceNotFound");
            }
            
            StaticDb.Burgers.FirstOrDefault(x => x.Id == burgerViewModel.Id).Id = burgerViewModel.Id;
            StaticDb.Burgers.FirstOrDefault(x => x.Id == burgerViewModel.Id).Name = burgerViewModel.Name;
            StaticDb.Burgers.FirstOrDefault(x => x.Id == burgerViewModel.Id).Price = burgerViewModel.Price;
            StaticDb.Burgers.FirstOrDefault(x => x.Id == burgerViewModel.Id).HasFries = burgerViewModel.HasFries;


            return RedirectToAction("Index");
        }

        public IActionResult DeleteBurger(int? id)
        {
            if (id == null)
            {
                return View("ResourceNotFound");
            }
            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(x => x.Id == id);

            if (burgerDb == null)
            {
                return View("ResourceNotFound");
            }
            int index = StaticDb.Burgers.FindIndex(x => x.Id == id);
            if (index == -1)
            {
                return View("ResourceNotFound");
            }
            StaticDb.Burgers.RemoveAt(index);
            return RedirectToAction("BurgerMenu");
        }
    }
}
