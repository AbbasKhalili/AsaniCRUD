using System.Data;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;

namespace AsaniCRUD.Wireup
{
    public class SessionFactoryBuilder
    {
        public static ISessionFactory Create(Assembly mappingAssembly, string connectionString, string sessionFactoryName)
        {
            var configuration = new Configuration();
            configuration.SessionFactoryName(sessionFactoryName);
            configuration.DataBaseIntegration(cfg =>
            {
                cfg.Dialect<MsSql2012Dialect>();
                cfg.Driver<SqlClientDriver>();
                cfg.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                cfg.ConnectionString = connectionString;
                cfg.IsolationLevel = IsolationLevel.ReadCommitted;
                cfg.Timeout = 30;
            });

            configuration.AddAssembly(mappingAssembly);
            var modelMapper = new ModelMapper();
            modelMapper.BeforeMapClass += (mi, t, map) => map.DynamicUpdate(true);
            modelMapper.AddMappings(mappingAssembly.GetExportedTypes());
            var mappingDocument = modelMapper.CompileMappingForAllExplicitlyAddedEntities();
            configuration.AddDeserializedMapping(mappingDocument, "Asan");

            return configuration.BuildSessionFactory();
        }
    }
}