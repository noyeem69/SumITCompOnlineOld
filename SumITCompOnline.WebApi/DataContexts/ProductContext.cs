using System.Data.Entity;
using SumITCompOnline.Entities;

namespace SumITCompOnline.WebApi.DataContexts
{
    public class ProductContext : DbContext, IProductContext
    {
        public ProductContext()
            : base("DefaultConnection")
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        public void MarkAsModified(Product item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}