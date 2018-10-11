using Autofac;
using System;

namespace MovieDbAppByM.DependencyInjection
{
    /// <summary>
    /// Represents the means to get <see cref="IContainer"/> as Lazy singleton.
    /// </summary>
    public sealed class IocContainerSingleton
    {
        /// <summary>
        /// A <see cref="Lazy{t}"/> implementation to obtain a singleton of type <see cref="IocContainerSingleton"/> 
        /// </summary>
        static readonly Lazy<IocContainerSingleton> lazy = new Lazy<IocContainerSingleton>(
            () => new IocContainerSingleton());

        /// <summary>
        /// A private constructor
        /// </summary>
        private IocContainerSingleton()
        {
            this.ConfigureIocContainer();
        }

        /// <summary>
        /// Public single instance of type <see cref="IocContainerSingleton"/> 
        /// </summary>
        public static IocContainerSingleton Instance => lazy.Value;

        /// <summary>
        /// Gets and sets <see cref="IContainer"/>
        /// </summary>
        public IContainer Container { get; private set; }

        /// <summary>
        /// Configures <see cref="IContainer"/> to be used in application.
        /// </summary>
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
