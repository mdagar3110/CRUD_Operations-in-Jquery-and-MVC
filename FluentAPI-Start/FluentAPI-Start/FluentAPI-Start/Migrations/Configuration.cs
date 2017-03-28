namespace FluentAPI_Start.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FluentAPI_Start.DAL.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FluentAPI_Start.DAL.DataContext context)
        {
            //context.Student.Add(new DAL.Student { Name = "Manish" });
            //context.StudentDetails.Add(new DAL.StudentDetails { Name = "Deepak", Address = "Delhi", ContactNo = "9887878676" });
            //context.StudentLogin.Add(new DAL.StudentLogin { Name = "Lalit", Password = "123456", Username = "lalit" });

        }
    }
}
