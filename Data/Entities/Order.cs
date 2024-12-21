using Techwork.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace techwork_after_america_return.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public string OrderNumber { get; set; }

        public ICollection<OrderItem> Items { get; set; } //we can relate one entity to another entity--->icollection

    }
}
