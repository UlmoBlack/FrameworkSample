using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAccess;
using DevFramework.NorthWind.Entities.ComplexTypes;
using DevFramework.NorthWind.Entities.Concrete;

namespace DevFramework.NorthWind.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetail> GetProductDetails();
        //
    }
}
