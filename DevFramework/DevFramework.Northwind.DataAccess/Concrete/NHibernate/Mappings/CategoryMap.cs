using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.NorthWind.Entities.Concrete;
using FluentNHibernate.Mapping;
using NHibernate;

namespace DevFramework.NorthWind.DataAccess.Concrete.NHibernate.Mappings
{
    public class CategoryMap:ClassMap<Category>
    {
        public CategoryMap()
        {
            Table(@"Categories");
            LazyLoad();
            Id(x => x.CategoryId).Column("CategoryId");
            Map(x => x.CategoryName).Column("CategoryName");
            }
    }
}
