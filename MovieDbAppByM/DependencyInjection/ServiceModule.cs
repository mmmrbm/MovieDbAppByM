using Autofac;
using MovieDbAppByM.Service;

namespace MovieDbAppByM.DependencyInjection
{
    /// <summary>
    /// <see cref="Module"> managing injectable classes of <see cref="Service" /> namespace
    /// </summary>
    public class ServiceModule : Module
    {
        /// <summary>
        /// <inheritdoc <see cref="Module"/> />
        /// </summary>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MoviePersistanceService>();
            builder.RegisterType<MovieRetrieveService>();
            builder.RegisterType<SettingManagementService>();
            builder.RegisterType<UserFileInfoPersistanceService>();
            builder.RegisterType<MovieProcessingService>();

            base.Load(builder);
        }
    }
}
