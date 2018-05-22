using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.NorthWind.Business.Abstract;
using DevFramework.NorthWind.Business.ValidationRules.FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Aspects.Postsharp;

namespace DevFramework.NorthWind.Business.Concrete.Managers
{
    class ProductManager : IProductService
    {

        private IProductDal _ProductDal;

        public ProductManager(IProductDal productDal)
        {
            _ProductDal = productDal;
        }

        [FluentValidationAspect(typeof(ProductValidatior))]
        public Product Add(Product product)
        {
            //ValidatorTool.FluentValidate(new ProductValidatior(), product);
            return _ProductDal.Add(product);
        }

        public List<Product> GetAll()
        {
            return _ProductDal.GetList();
        }

        public Product GetById(int id)
        {
            return _ProductDal.Get(p => p.ProductId == id);
        }

        [FluentValidationAspect(typeof(ProductValidatior))]
        public Product Update(Product product)
        {
           // ValidatorTool.FluentValidate(new ProductValidatior(), product);
            return _ProductDal.Update(product);
        }
    }
}
