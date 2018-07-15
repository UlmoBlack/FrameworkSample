using DevFramework.NorthWind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.NorthWind.Business.Abstract
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        List<Product> GetAll();
        [OperationContract]
        Product GetById(int id);
        [OperationContract]
        Product Add(Product product);
        [OperationContract]
        Product Update(Product product);

        void TransactionalOperation(Product prudct1, Product product2);
    }
}
