using Autofac;
using MovieDbAppByM.Service;

namespace MovieDbAppByM.DependencyInjection
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MoviePersistanceService>();
            builder.RegisterType<MovieRetrieveService>();
            builder.RegisterType<SettingManagementService>();

            base.Load(builder);
        }
    }
}
