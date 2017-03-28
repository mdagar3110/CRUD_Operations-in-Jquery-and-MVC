using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace MVC_PagingSortingSearching.DAL
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("Default")
        {

        }

        public DbSet<User> User { get; set; }
    }
}