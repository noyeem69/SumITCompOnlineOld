namespace SumITCompOnline.WebApi.Migrations
{
    using SumITCompOnline.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SumITCompOnline.WebApi.DataContexts.ProductContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SumITCompOnline.WebApi.DataContexts.ProductContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Products.AddOrUpdate(
                  p => p.Id,
                  new Product { Id = 1, Title = "Product1", Description = "the hyper secret", Price = 100, Quantity = 10 },
                  new Product { Id = 2, Title = "Product2", Description = "Test Web API", Price = 200, Quantity = 10 },
                  new Product { Id = 3, Title = "Product3", Description = "REST", Price = 300, Quantity = 10 }
                );
        }
    }
}
