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
                return new EmptyResult();
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

            //return View(orderDb);
            return View(orderDetailsViewModel);
        }
        
    }
}
