using Autofac;
using System;

namespace MovieDbAppByM.DependencyInjection
{
    public sealed class IocContainerSingleton
    {
        static readonly Lazy<IocContainerSingleton> lazy = new Lazy<IocContainerSingleton>(
            () => new IocContainerSingleton());

        private IocContainerSingleton()
        {
            this.ConfigureIocContainer();
        }

        public static IocContainerSingleton Instance => lazy.Value;

        public IContainer Container { get; private set; }

        private void ConfigureIocContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule<PersistanceModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<UtilityModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<MappingModule>();

            this.Container = builder.Build();
        }
    }
}
