using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Mappers;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            List<Order> ordersDb = StaticDb.Orders;

            //dynamic a = 5;
            //a.name = 100;


            //List<OrderDetailsViewModel> orderViewModels = ordersDb.Select(x => new OrderDetailsViewModel
            //{
            //    PaymentMethod = x.PaymentMethod,
            //    PizzaName = x.Pizza.Name,
            //    Price = x.Pizza.Price + 50,
            //    UserFullName = $"{x.User.FirstName} {x.User.LastName}"
            //}).ToList();

            //List<OrderDetailsViewModel> viewModels = new List<OrderDetailsViewModel>();

            //foreach (Order order in ordersDb)
            //{
            //    viewModels.Add(new OrderDetailsViewModel
            //    {
            //        PaymentMethod = order.PaymentMethod,
            //        PizzaName = order.Pizza.Name,
            //        Price = order.Pizza.Price + 50,
            //        UserFullName = $"{order.User.FirstName} {order.User.LastName}"
            //    });
            //}

            List<OrderDetailsViewModel> orderViewModels = ordersDb.Select(x => OrderMapper.ToOrderDetailsViewModel(x)).ToList();

            ViewData["Title"] = "These are the orders made with our app:";
            ViewData["NumberOfOrders"] = StaticDb.Orders.Count;

            ViewData["FirstUser"] = StaticDb.Orders.First().User;

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
                //return new EmptyResult();
                //return View(); //Details.cshtml -> Order folder
                return View("ResourceNotFound"); //we pass the name of the View
            }

            // map from domain to view model

            //OrderDetailsViewModel orderDetailsViewModel = new OrderDetailsViewModel
            //{
            //    PaymentMethod = orderDb.PaymentMethod,
            //    PizzaName = orderDb.Pizza.Name,
            //    Price = orderDb.Pizza.Price + 50,
            //    UserFullName = $"{orderDb.User.FirstName} {orderDb.User.LastName}"
            //};


            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.ToOrderDetailsViewModel(orderDb);

            ViewBag.Title = $"Details for order with id {id}";
            ViewBag.User = orderDb.User;

            //return View(orderDb);

            return View(orderDetailsViewModel);
        }
        
    }
}
