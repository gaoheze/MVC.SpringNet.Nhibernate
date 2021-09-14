using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nancal.Mvc.Demo
{
    public class BookMap : ClassMapping<Book>
    {
        public BookMap()
        {
            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Guid);
                x.Type(NHibernateUtil.Guid);
                x.Column("Id");
                x.UnsavedValue(Guid.Empty);
            });

            Property(b => b.Title, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.Remark, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(p => p.CreateTime, map => map.Type(NHibernateUtil.DateTime));

            Version(v => v.UpdateTime, map => map.Type(NHibernateUtil.DateTime));

            Table("Book");
        }
    }
}