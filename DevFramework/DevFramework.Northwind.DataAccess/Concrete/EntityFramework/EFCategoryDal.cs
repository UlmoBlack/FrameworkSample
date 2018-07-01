using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.NorthWind.DataAccess.Abstract;
using DevFramework.NorthWind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.NorthWind.DataAccess.Concrete.EntityFramework
{
    public class EFCategoryDal:EfEntityRepositoryBase<Category,NorthWindContext>, ICategoryDal
    {

    }
}
