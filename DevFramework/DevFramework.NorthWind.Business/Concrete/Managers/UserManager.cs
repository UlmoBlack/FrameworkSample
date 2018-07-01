using DevFramework.NorthWind.DataAccess.Concrete.EntityFramework;
using DevFramework.NorthWind.Entities.Concrete;
using DevFramework.NorthWind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.NorthWind.DataAccess.Abstract;
using DevFramework.NorthWind.Entities.ComplexTypes;

namespace DevFramework.NorthWind.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetByUserNameAndPassword(string userName, string password)
        {
            return _userDal.Get(u => u.UserName == userName & u.Password == password);
        }

        public List<UserRoleItem> GetUserRoles(User user)
        {
            return _userDal.GetUserRoles(user);
        }
    }
}
