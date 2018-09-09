using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.Domain.Abstract;
using TestTask.Domain.Entities;
using TestTask.WebUI.Models;

namespace TestTask.WebUI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private IOrderRepository _repository;
        public int PageSize = 4;

        public OrderController(IOrderRepository repository)
        {
            _repository = repository;
        }

        public ViewResult List(string manager , int page = 1)
        {

            OrdersListViewModel model = new OrdersListViewModel
            {
                Orders = _repository.Orders
                    .OrderBy(p => p.Number)
                    .Where(p => p.Manager.Contains(manager ?? ""))
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _repository.Orders.Count(p => p.Manager.Contains(manager ?? ""))
                }
            };

            return View(model);
        }

        public ViewResult Edit(int orderId)
        {
            Order product = _repository.Orders
                .FirstOrDefault(p => p.OrderId == orderId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveOrder(order);
                TempData["message"] = $"Order #{order.Number} has been saved";
                return RedirectToAction("List");
            }
            else
            {
                return View(order);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Order());
        }
    }
}