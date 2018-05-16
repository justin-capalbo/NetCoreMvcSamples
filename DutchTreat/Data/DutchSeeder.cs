using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutchTreat.Data.Entities;
using DutchTreat.Views.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace DutchTreat.Data
{
    public class DutchSeeder
    {
        private readonly DutchContext _ctx;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<StoreUser> _userManager;

        public DutchSeeder(DutchContext ctx, IHostingEnvironment hosting, UserManager<StoreUser> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task Seed()
        {
            //Make sure that before we try to issue any queries, the database actually exists.  
            _ctx.Database.EnsureCreated();

            var user = await _userManager.FindByEmailAsync("capalbo.justin@gmail.com");

            if (user == null)
            {
                user = new StoreUser
                {
                    FirstName = "Justin",
                    LastName = "Capalbo",
                    UserName = "capalbo.justin@gmail.com",
                    Email = "capalbo.justin@gmail.com"
                };
                var result = await _userManager.CreateAsync(user, "N!tsuj123");
                if (result == IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create the default user");
                }
            }

            if (!_ctx.Products.Any())
            {
                //Need to create sample data
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/art.json");
                var json = File.ReadAllText(filepath);

                //Deserialize the list of art in the json file
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);

                //Add products to the context.  Not yet ready to save.
                _ctx.Products.AddRange(products);

                //Create a sample order.
                var order = new Order
                {
                    User = user,
                    OrderDate = DateTime.Now,
                    OrderNumber = "12345",
                    Items = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price,
                        }
                    }
                };
                _ctx.Orders.Add(order);
                
                //Finally, save the changes.
                _ctx.SaveChanges();
            }
        }
    }
}
