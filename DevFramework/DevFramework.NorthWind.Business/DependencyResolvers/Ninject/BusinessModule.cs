using DevFramework.NorthWind.Business.Abstract;
using DevFramework.NorthWind.Business.Concrete.Managers;
using DevFramework.NorthWind.DataAccess.Abstract;
using DevFramework.NorthWind.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAccess;
using DevFramework.Core.DataAccess.EntityFramework;
using System.Data.Entity;
using DevFramework.Core.DataAccess.NHibernate;
using DevFramework.NorthWind.DataAccess.Concrete.NHibernate.Helpers;
using DevFramework.NorthWind.Business.Abstract;
using DevFramework.NorthWind.Business.Concrete.Managers;

namespace DevFramework.NorthWind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
            Bind<IUserService>().To<UserManager>();
            Bind<IUserDal>().To<EfUserDal>();

            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQuaryableRepository<>));
            Bind<DbContext>().To<NorthWindContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}
