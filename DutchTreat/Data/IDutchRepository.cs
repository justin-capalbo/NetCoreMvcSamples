using System.Collections.Generic;
using DutchTreat.Data.Entities;

namespace DutchTreat.Data
{
    //The interface allows us to easily create a mock version of this repository that's easy to mock up so we're not testing against the actual DB.
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetAllProductsByCategory(string category);
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);

        bool SaveAll();
    }
}