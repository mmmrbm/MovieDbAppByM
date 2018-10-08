using Autofac;
using MovieDbAppByM.View;

namespace MovieDbAppByM.DependencyInjection
{
    public class ViewModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindow>();
            builder.RegisterType<ScraperWindow>();

            base.Load(builder);
        }
    }
}
