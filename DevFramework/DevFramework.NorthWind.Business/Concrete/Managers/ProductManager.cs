using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Aspects.Postsharp;
using System.Transactions;
using DevFramework.Core.Aspects.Postsharp.ValidationAspects;
using DevFramework.Core.Aspects.Postsharp.TransactionAspects;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using DevFramework.Core.Aspects.Postsharp.LogAspects;
using DevFramework.Core.Aspects.Postsharp.PerformanceAspects;
using System.Threading;
using DevFramework.Core.Aspects.Postsharp.AuthorizationAspects;

namespace DevFramework.Northwind.Business.Concrete.Managers
{

    public class ProductManager : IProductService
    {

        private IProductDal _ProductDal;

        public ProductManager(IProductDal productDal)
        {
            _ProductDal = productDal;
        }

        [FluentValidationAspect(typeof(ProductValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        public Product Add(Product product)
        {
            //ValidatorTool.FluentValidate(new ProductValidatior(), product);
            return _ProductDal.Add(product);
        }

        [CacheAspect(typeof(MemoryCacheManager), 120)]
        [PerformanceCounterAspect(2)]
        [SecuriedOperation(Roles="Admin,Editor")]
        public List<Product> GetAll()
        {
            Thread.Sleep(3000);
            return _ProductDal.GetList();
        }
        [FluentValidationAspect(typeof(ProductValidatior))]
        public Product GetById(int id)
        {
            return _ProductDal.Get(p => p.ProductId == id);
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(ProductValidatior))]
        public void TransactionalOperation(Product prudct1, Product product2)
        {

            _ProductDal.Add(prudct1);
            _ProductDal.Update(product2);



        }

        // [FluentValidationAspect(typeof(ProductValidatior))]
        public Product Update(Product product)
        {
            // ValidatorTool.FluentValidate(new ProductValidatior(), product);
            return _ProductDal.Update(product);
        }
    }
}
