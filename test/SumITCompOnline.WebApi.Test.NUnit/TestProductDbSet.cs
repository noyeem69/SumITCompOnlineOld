using System.Linq;
using SumITCompOnline.Entities;

namespace SumITCompOnline.WebApi.Test
{
    class TestProductDbSet : TestDbSet<Product>
    {
        public override Product Find(params object[] keyValues)
        {
            return this.SingleOrDefault(product => product.Id == (int)keyValues.Single());
        }
    }
}