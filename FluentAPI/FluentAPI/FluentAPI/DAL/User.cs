using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FluentAPI.DAL
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }

        public int OrdId { get; set; }

        public virtual Order Order { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}