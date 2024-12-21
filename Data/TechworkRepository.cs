using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techwork.Data.Entities;
using Microsoft.Extensions.Logging;
using techwork_after_america_return.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace techwork_after_america_return.Data
{
    public class TechworkRepository : ITechworkRepository //ctrl+.  since interface added so update even inthis interface
    {
        private readonly TechworkContext _ctx;
        private readonly ILogger<TechworkRepository> _logger;
        public TechworkRepository(TechworkContext ctx, ILogger<TechworkRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }


        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
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

            public Order GetOrderById(int id)
        {
            return _ctx.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }




        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("GetAllProducts were created");
                return _ctx.Products
                        .OrderBy(p => p.Artist)
                        .ToList();
            }
            catch
            {
                _logger.LogError("error:{ex}");
                return null;
            }

        }
       
    

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _ctx.Products
                .Where(p => p.Category == category)
                .ToList();
        }

        public bool SaveAll() => throw new NotImplementedException();

    
      

       // Order ITechworkRepository.GetOrderById(int id) => throw new NotImplementedException();
        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }
    }
}

/* public IEnumerable<Order> GetAllOrders()
      {
          return _ctx.Orders
              .Include(o => o.Items)
              .ThenInclude(i => i.Product)
              .ToList();//it has self referensing order order and order item both are coonected in database
      }
   /*public IEnumerable<Order> GetAllOrders()
        {
            return _ctx.Orders
              .Include(o => o.Items)
              .ThenInclude(i => i.Product)
              .ToList();
        }*/




