using Autofac;
using Settings.Domain.AggregatesModel.SettingEntityAggregate;
using Settings.Infrastructure.Repositories;

namespace Settings.API.Infrastructure.AutofacModules
{
    public class ApplicationModule : Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string conn)
        {
            QueriesConnectionString = conn;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SettingEntityRepository>()
                .As<ISettingEntityRepository>()
                .InstancePerLifetimeScope();
        }
    }
}