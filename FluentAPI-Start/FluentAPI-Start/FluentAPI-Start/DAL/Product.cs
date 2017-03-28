using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FluentAPI_Start.DAL
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int CatID { get; set; }
        public virtual Category Category { get; set; }
    }
}