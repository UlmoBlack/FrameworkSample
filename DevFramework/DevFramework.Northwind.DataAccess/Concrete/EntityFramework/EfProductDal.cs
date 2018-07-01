using System.Collections.Generic;
using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.NorthWind.DataAccess.Abstract;
using DevFramework.NorthWind.Entities.ComplexTypes;
using DevFramework.NorthWind.Entities.Concrete;
using System.Linq;
namespace DevFramework.NorthWind.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthWindContext>, IProductDal
    {
        public List<ProductDetail> GetProductDetails()
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories on p.CategoryId equals c.CategoryId
                             select new ProductDetail
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName
                             };
                return result.ToList();
            }
        }
    }
}
