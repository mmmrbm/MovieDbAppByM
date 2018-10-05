using Autofac;
using MovieDbAppByM.Utility;

namespace MovieDbAppByM.DependencyInjection
{
    public class UtilityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ImageFetchUtil>();
            builder.RegisterType<MovieInfoFetchUtil>();
            builder.RegisterType<MovieImageTypes>();

            base.Load(builder);
        }
    }
}
