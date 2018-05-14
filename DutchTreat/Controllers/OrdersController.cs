using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DutchTreat.Controllers
{
    [Route("api/[Controller]")]
    public class OrdersController : Controller
    {
        private readonly IDutchRepository _repository;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IDutchRepository repository, ILogger<OrdersController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllOrders());
            }
            catch (Exception ex)
            {
                string responseMsg = "Failed to get orders";
                _logger.LogError($"{responseMsg}: {ex}");
                return BadRequest(responseMsg);
            }
        }

        //Overloading a route for the same verb, adding a typed parameter
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var order = _repository.GetOrderById(id);

                if (order != null) return Ok(order);
                else return NotFound();
            }
            catch (Exception ex)
            {
                string responseMsg = "Failed to get order";
                _logger.LogError($"{responseMsg}: {ex}");
                return BadRequest(responseMsg);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]OrderViewModel model) 
        {
            string responseMsg = "Failed to save a new order";

            try
            {
                //Here we can validate through the view model, but we have to go through the trouble of converting the View model to the order.
                if (ModelState.IsValid)
                {
                    var newOrder = new Order
                    {
                        OrderDate = model.OrderDate,
                        OrderNumber = model.OrderNumber,
                        Id = model.OrderId
                    };

                    if (newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }

                    _repository.AddEntity(newOrder);
                    if (_repository.SaveAll())
                    {
                        var vm = new OrderViewModel
                        {
                            OrderDate = newOrder.OrderDate,
                            OrderNumber = newOrder.OrderNumber,
                            OrderId = newOrder.Id
                        };
                        return Created($"/api/orders/{vm.OrderId}", vm);
                    }
                }
                else
                {
                    //This way we see what's actually wrong with the model
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{responseMsg}: {ex}");
            }

            return BadRequest(responseMsg);
        }
    }
}
