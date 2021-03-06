﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DutchTreat.Data
{
    //This is the concrete implementation of our query bucket, which is more or less what the repository pattern is - a list of pre-canned queries and a singular place for us to
    //interact with the context/dbconnection if using something like Dapper.
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext _ctx;
        private readonly ILogger<DutchRepository> _logger;

        //Logger for this class allows us to see where the log came from
        public DutchRepository(DutchContext ctx, ILogger<DutchRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("GetAllProducts");

                return _ctx.Products
                           .OrderBy(p => p.Title)
                           .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
        }

        public IEnumerable<Product> GetAllProductsByCategory(string category)
        {
            try
            {
                return _ctx.Products
                           .Where(p => p.Category == category)
                           .OrderBy(p => p.Title)
                           .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            try
            {
                _logger.LogInformation("GetAllOrders");

                //Include nested relationships here in a cascading fashion
                if (includeItems)
                {
                    return _ctx.Orders
                               .Include(o => o.Items)
                               .ThenInclude(i => i.Product)
                               .ToList();
                }
                else
                {
                    return _ctx.Orders
                               .ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all orders: {ex}");
                return null;
            }
        }

        public IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems)
        {
            try
            {
                _logger.LogInformation($"GetAllOrdersByUser {username}");

                //Include nested relationships here in a cascading fashion
                if (includeItems)
                {
                    return _ctx.Orders
                               .Where(o => o.User.UserName == username)
                               .Include(o => o.Items)
                               .ThenInclude(i => i.Product)
                               .ToList();
                }
                else
                {
                    return _ctx.Orders
                               .Where(o => o.User.UserName == username)
                               .ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all orders: {ex}");
                return null;
            }
        }

        public Order GetOrderById(string username, int id)
        {
            try
            {
                _logger.LogInformation("GetOrderById");

                return _ctx.Orders
                           .Where(o => o.User.UserName == username)
                           .Where(o => o.Id == id)
                           .Include(o => o.Items)
                           .ThenInclude(i => i.Product)
                           .FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all orders: {ex}");
                return null;
            }
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

        public void AddOrder(Order newOrder)
        {
            //Convert new products to lookup of product
            foreach (var item in newOrder.Items)
            {
                item.Product = _ctx.Products.Find(item.Product.Id);
            }
            AddEntity(newOrder);
        }
    }
}
