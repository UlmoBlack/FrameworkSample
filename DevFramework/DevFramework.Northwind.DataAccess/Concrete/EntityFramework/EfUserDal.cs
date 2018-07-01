using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.NorthWind.DataAccess.Abstract;
using DevFramework.NorthWind.Entities.ComplexTypes;
using DevFramework.NorthWind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.NorthWind.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthWindContext>, IUserDal
    {
        public List<UserRoleItem> GetUserRoles(User user)
        {
            using (NorthWindContext context=new NorthWindContext())
            {
                var result = from ur in context.UserRoles
                             join r in context.Roles
                             on ur.RoleId equals r.Id
                             where ur.UserId == user.Id
                             select new UserRoleItem { RoleName = r.Name };
                return result.ToList();
            }
        }
    }
}
