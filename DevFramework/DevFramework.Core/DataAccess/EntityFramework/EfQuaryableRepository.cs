using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.EntityFramework
{
    public class EfQuaryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private DbContext _context;
        private IDbSet<T> _entities;

        public EfQuaryableRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table => this.Entities; // Table çağırıldığında this.Entities return edilecek
        //{
        //    get
        //    {
        //        return this.Entities;
        //    }
        //}

        protected virtual IDbSet<T> Entities
        {

            get { return _entities ?? (_entities = _context.Set<T>()); } // Eğer context null ise eski halini gönder
            //get
            //{
            //    if(_entities == null)
            //    {
            //        _entities = _context.Set<T>();

            //    }
            //    return _entities;
            //}
        }

    }
}
