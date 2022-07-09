using BurgerApp.Models.Domain;
using BurgerApp.Models.Mappers;
using BurgerApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            List<Order> ordersDb = StaticDb.Orders;

            List<OrderViewModel> orderViewModels = ordersDb.Select(x => OrderMapper.ToOrderViewModel(x)).ToList();

            ViewData["Title"] = "These are the orders...";
            ViewData["NumberOfOrders"] = StaticDb.Orders.Count;

            return View(orderViewModels);
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return new EmptyResult();
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if(orderDb == null)
            {
                return View("ResourceNotFound");
            }

            OrderViewModel orderViewModel = OrderMapper.ToOrderViewModel(orderDb);

            return View(orderViewModel);
        }

        public IActionResult MakeNewOrder()
        {
            OrderViewModel orderViewModel = new OrderViewModel();

            ViewBag.Burgers = StaticDb.Burgers.Select(x => new BurgerViewModel
            {
                Name = x.Name,
            });

            ViewBag.Orders = StaticDb.Orders.Select(x => new OrderViewModel
            {
                FullName = x.FullName,
            });

            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult MakeNewOrderPost(OrderViewModel orderViewModel)
        {

            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(x => x.Name == orderViewModel.FullName);
            if(burgerDb == null)
            {
                return View("ResourceNotFound");
            }

            Order newOrder = new Order
            {
                Id = StaticDb.OrderId + 1,
                FullName = orderViewModel.FullName,
                Address = orderViewModel.Address,
                IsDelivered = orderViewModel.IsDelivered,
                BurgerFlavour = orderViewModel.BurgerFlavour,
                Location = orderViewModel.Location
            };

            StaticDb.Orders.Add(newOrder);
            StaticDb.OrderId++;

            return RedirectToAction("Index");
        }

        public IActionResult EditOrder(int? id)
        {
            if(id == null)
            {
                return View("ResourceNotFound");
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if(orderDb == null)
            {
                return View("ResourceNotFound");
            }

            ViewBag.Burgers = StaticDb.Burgers.Select(x => new BurgerViewModel
            {
                Name = x.Name,
            });

            ViewBag.Orders = StaticDb.Orders.Select(x => new OrderViewModel
            {
                FullName = x.FullName,
            });

            OrderViewModel orderViewModel = OrderMapper.ToOrderViewModel(orderDb);
            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult EditOrderPost(OrderViewModel orderViewModel)
        {
            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id);
            if (orderDb == null)
            {
                return View("ResourceNotFound");
            }

            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(x => x.Name == orderViewModel.FullName);
            if (burgerDb == null)
            {
                return View("ResourceNotFound");
            }

            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).Id = orderViewModel.Id;
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).FullName = orderViewModel.FullName;
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).Address = orderViewModel.Address; 
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).IsDelivered = orderViewModel.IsDelivered; 
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).BurgerFlavour = orderViewModel.BurgerFlavour; 
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).Location = orderViewModel.Location;

            return RedirectToAction("Index");
        }

        public IActionResult DeleteOrder(int? id)
        {
            if(id == null)
            {
                return View("RecourceNotFound");
            }

            Order order = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if(order == null)
            {
                return View("ResourceNotFound");
            }

            int index = StaticDb.Orders.FindIndex(x => x.Id == id);
            if(index == -1)
            {
                return View("ResourceNotFound");
            }

            StaticDb.Orders.RemoveAt(index);

            return RedirectToAction("Index");
        }


    }
}
