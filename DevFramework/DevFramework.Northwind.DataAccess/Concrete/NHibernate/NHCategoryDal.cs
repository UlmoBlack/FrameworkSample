using DevFramework.Core.DataAccess.NHibernate;
using DevFramework.NorthWind.DataAccess.Abstract;
using DevFramework.NorthWind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.NorthWind.DataAccess.Concrete.NHibernate
{
    public class NHCategoryDal : NhEntitiyRepositoryBase<Category>, ICategoryDal
    {
        public NHCategoryDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }
    }
}
