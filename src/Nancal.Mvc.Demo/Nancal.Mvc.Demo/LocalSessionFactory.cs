using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;

using Spring.Data.NHibernate;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Nancal.Mvc.Demo
{
    public class LocalSessionFactory : LocalSessionFactoryObject
    {
        public string[] ModelAssemblyName { set; get; }

        protected override void PostProcessConfiguration(Configuration config)
        {
            var mapper = new ModelMapper();
            mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            config.DataBaseIntegration(c =>
            {
                //c.Dialect<Oracle12cDialect>();
                //c.Driver<OracleManagedDataClientDriver>();
                //c.Dialect<MsSql2012Dialect>();
                //c.ConnectionString = @"server=.;uid=sa;pwd=Sa@123456;database=test";
                c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                c.SchemaAction = SchemaAutoAction.Update;
                c.LogFormattedSql = true;
                c.LogSqlInConsole = true;
            });
            config.AddMapping(domainMapping);

            base.PostProcessConfiguration(config);
        }
    }
}