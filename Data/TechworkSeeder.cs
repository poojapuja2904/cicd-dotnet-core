using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Techwork.Data.Entities;
using techwork_after_america_return.Data.Entities;

namespace techwork_after_america_return.Data
{
    public class TechworkSeeder
    {
        private readonly TechworkContext _ctx;
        private readonly IWebHostEnvironment _hosting;
        public TechworkSeeder(TechworkContext ctx, IWebHostEnvironment hosting)//we need innterface where environment run in
        {
            _ctx = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated(); // this make shore database exhist to avoid exception

            if(!_ctx.Products.Any())
            {
                //have to create product
                var filePath = Path.Combine(_hosting.ContentRootPath,"Data/art.json");  //IO
                var json = File.ReadAllText(filePath);
                var products = JsonSerializer.Deserialize<IEnumerable<Product>>(json);

                _ctx.Products.AddRange(products);

                var order1 = new Order()
                {
                    OrderDate = DateTime.Today,
                    OrderNumber = "10000",
                    Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price

                        }
                    }

                };
                _ctx.Orders.Add(order1);
                _ctx.SaveChanges();
            }
        }
      
        }
    }

