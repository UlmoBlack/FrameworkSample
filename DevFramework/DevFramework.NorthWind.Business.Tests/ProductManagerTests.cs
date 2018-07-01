using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentValidation;
using DevFramework.NorthWind.DataAccess.Concrete.EntityFramework;
using DevFramework.NorthWind.DataAccess.Abstract;
using DevFramework.NorthWind.Business.Concrete.Managers;
using DevFramework.NorthWind.Entities.Concrete;

namespace DevFramework.NorthWind.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {

        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_Validation_Check()
        {
            //Mock<IProductDal> mock = new Mock<IProductDal>();
      
            //ProductManager productManager = new ProductManager(mock.Object);
            //productManager.Add(new Product());
        }
    }
}
