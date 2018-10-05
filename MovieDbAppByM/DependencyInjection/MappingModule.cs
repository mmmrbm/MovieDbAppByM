using Autofac;

namespace MovieDbAppByM.DependencyInjection
{
    public class MappingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AutoMapperConfig>();

            base.Load(builder);
        }
    }
}
