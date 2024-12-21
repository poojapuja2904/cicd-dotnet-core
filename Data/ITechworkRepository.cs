using System.Collections.Generic;
using Techwork.Data.Entities;
using techwork_after_america_return.Data.Entities;

namespace techwork_after_america_return.Data
{
    public interface ITechworkRepository 
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);

        // object GetAllOrders(); //here it is created so change
       IEnumerable<Order> GetAllOrders(bool includeItems); //here it is created
        Order GetOrderById(int id);
        bool SaveAll();
        void AddEntity(object model);//any entity type will be able to handle with object
       // Order GetAllOrders(Order includeItems);//me written
        // void AddEntity(object model);
    }
}