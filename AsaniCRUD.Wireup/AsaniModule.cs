using System.Data;
using System.Data.Common;
using AsaniCRUD.Application;
using AsaniCRUD.Facade.Query;
using AsaniCRUD.Facade.Services;
using AsaniCRUD.Persistence;
using AsaniCRUD.Persistence.Mappings;
using AsaniCRUD.ReadModel;
using Autofac;
using Framework.Application;
using Framework.Autofac;
using Framework.Core;
using Framework.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NHibernate;

namespace AsaniCRUD.Wireup
{
    public class AsaniModule : Module
    {
        private readonly string _connectionString;

        public AsaniModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(EstateRepository).Assembly)
                .Where(a => typeof(IRepository).IsAssignableFrom(a))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(EstateFacadeService).Assembly)
                .Where(a => typeof(IFacadeService).IsAssignableFrom(a))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(EstateFacadeQuery).Assembly)
                .Where(a => typeof(IFacadeService).IsAssignableFrom(a))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(typeof(EstateCommandHandler).Assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>)).InstancePerLifetimeScope();

            var sessionFactory = SessionFactoryBuilder.Create(typeof(EstateMapping).Assembly, _connectionString, "Asani");
            builder.Register<ISession>(a =>
            {
                var session = sessionFactory.OpenSession();
                return session;
            }).InstancePerLifetimeScope().OnRelease(a => a.Close());


            builder.Register<DbConnection>(z =>
            {
                var connection = new SqlConnection(_connectionString);
                connection.Open();
                return connection;
            }).InstancePerLifetimeScope().As<IDbConnection>().OnRelease(a => a.Close());


            builder.Register<AsaniContext>(s =>
            {
                var options = new DbContextOptionsBuilder<AsaniContext>()
                    .UseSqlServer(_connectionString)
                    .Options;
                var context = new AsaniContext(options);
                return context;
            }).InstancePerLifetimeScope().OnRelease(a => a.Dispose());



            builder.RegisterGenericDecorator(typeof(TransactionalCommandHandlerDecorator<>), typeof(ICommandHandler<>));

            builder.RegisterType<CommandBus>().As<ICommandBus>()
                .SingleInstance();

            builder.RegisterType<NhUnitOfWork>().As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AutofacServiceLocator>().As<IServiceLocator>()
                .SingleInstance();

        }
    }

    public static class ArmedServiceLocator
    {
        public static void Assign(IContainer container)
        {
            ServiceLocator.Set(new AutofacServiceLocator(container));
        }
    }
}
