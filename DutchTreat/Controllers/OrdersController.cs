using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
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
        public IActionResult Post([FromBody]Order model) 
        {
            string responseMsg = "Failed to save a new order";

            //Add it to the database
            try
            {
                _repository.AddEntity(model);
                if (_repository.SaveAll())
                {
                    return Created($"/api/orders/{model.Id}", model);
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
