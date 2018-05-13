using DevFramework.Core.Entities;
using System;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.NHibernate
{
    public class NhEntitiyRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private NHibernateHelper _nHibernetHelper;

        public NhEntitiyRepositoryBase(NHibernateHelper nHibernateHelper)
        {
            _nHibernetHelper = nHibernateHelper;
        }
        public TEntity Add(TEntity entity)
        {
            using (var session = _nHibernetHelper.OpenSession())
            {
                session.Save(entity);
                return entity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var session = _nHibernetHelper.OpenSession())
            {
                session.Delete(entity);

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var session = _nHibernetHelper.OpenSession())
            {
                return session.Query<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var session = _nHibernetHelper.OpenSession())
            {
                return filter == null
                    ? session.Query<TEntity>().ToList()
                    : session.Query<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var session = _nHibernetHelper.OpenSession())
            {
                session.Update(entity);
                return entity;
            }
        }
    }
}
