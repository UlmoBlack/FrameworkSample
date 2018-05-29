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
        public Product Add(Product product)
        {
            //ValidatorTool.FluentValidate(new ProductValidatior(), product);
            return _ProductDal.Add(product);
        }

        [FluentValidationAspect(typeof(ProductValidatior))]
        public List<Product> GetAll()
        {
            return _ProductDal.GetList();
        }
        [FluentValidationAspect(typeof(ProductValidatior))]
        public Product GetById(int id)
        {
            return _ProductDal.Get(p => p.ProductId == id);
        }

       // [FluentValidationAspect(typeof(ProductValidatior))]
        public Product Update(Product product)
        {
           // ValidatorTool.FluentValidate(new ProductValidatior(), product);
            return _ProductDal.Update(product);
        }
    }
}
