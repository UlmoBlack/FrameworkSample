using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevFramework.DataAccess;
using DevFramework.Northwind.DataAccess.Concrete.NHibernate;
using DevFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers;

namespace DevFramework.DataAccess.Tests.NhibernateTests
{
    [TestClass]
    public class NhibernateTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList();

            Assert.AreEqual(77, result.Count);
        }

        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_all_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList(p=> p.ProductName.Contains("ab"));

            Assert.AreEqual(4, result.Count);
        }
    }
}
