using System.Data.Entity;
using SumITCompOnline.Entities;
using SumITCompOnline.WebApi.DataContexts;

namespace SumITCompOnline.WebApi.Test
{
    public class TestProductContext : IProductContext
    {
        public TestProductContext()
        {
            this.Products = new TestProductDbSet();
        }

        public DbSet<Product> Products { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Product item) { }
        public void Dispose() { }
    }
}