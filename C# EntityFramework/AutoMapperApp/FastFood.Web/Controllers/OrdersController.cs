﻿namespace FastFood.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;

    using Data;
    using ViewModels.Orders;
    using FastFood.Models;
    using AutoMapper.QueryableExtensions;
    using FastFood.Models.Enums;

    public class OrdersController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public OrdersController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            var viewOrder = new CreateOrderViewModel
            {
                Items = this.context.Items.Select(x => x.Id).ToList(),
                Employees = this.context.Employees.Select(x => x.Id).ToList(),
            };

            return this.View(viewOrder);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");

            }

            var order = mapper.Map<Order>(model);

            order.DateTime = DateTime.Now;
            order.Type = Enum.Parse<OrderType>(model.OrderType);
            order.OrderItems.Add(new OrderItem()
            {
                ItemId = model.ItemId,
                Order = order,
                
            }) ; 


            

            context.Add(order);
            context.SaveChanges();

            return RedirectToAction("All");
        }

        public IActionResult All()
        {
            var orders = context.Orders
                         .ProjectTo<OrderAllViewModel>(mapper.ConfigurationProvider)
                         .ToList();

            return View(orders);
        }
    }
}
