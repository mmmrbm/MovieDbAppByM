using Autofac;
using MovieDbAppByM.Persistance;

namespace MovieDbAppByM.DependencyInjection
{
    public class PersistanceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MovieAppDbContext>().SingleInstance();
            base.Load(builder);
        }
    }
}
