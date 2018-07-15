using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using DevFramework.NorthWind.DataAccess.Abstract;
using DevFramework.NorthWind.Entities.Concrete;
using DevFramework.NorthWind.Business.Abstract;
using DevFramework.NorthWind.Business.ValidationRules.FluentValidation;
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
using AutoMapper;
using DevFramework.Core.Utilities.Mappings;

namespace DevFramework.NorthWind.Business.Concrete.Managers
{

    public class ProductManager : IProductService
    {

        private IProductDal _ProductDal;
        private IMapper _mapper;

        public ProductManager(IProductDal productDal,IMapper mapper)
        {
            _ProductDal = productDal;
            _mapper = mapper;
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
        public List<Product> GetAll()
        {
            // Thread.Sleep(3000);

            //return _ProductDal.GetList().Select(p=> new Product
            //{
            //    CategoryId = p.CategoryId,
            //    ProductId = p.ProductId,
            //    ProductName =p.ProductName,
            //    QuantityPerUnit = p.QuantityPerUnit,
            //    UnitPrice = p.UnitPrice
            //}).ToList();
            List<Product> products = _mapper.Map<List<Product>>(_ProductDal.GetList());
            return products;
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
