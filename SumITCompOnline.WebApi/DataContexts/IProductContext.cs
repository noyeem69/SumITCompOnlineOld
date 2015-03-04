using System;
using System.Data.Entity;
using SumITCompOnline.Entities;

namespace SumITCompOnline.WebApi.DataContexts
{
    public interface IProductContext : IDisposable
    {
        DbSet<Product> Products { get; }
        int SaveChanges();
        void MarkAsModified(Product product);
    }
}