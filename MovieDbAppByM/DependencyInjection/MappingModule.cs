using Autofac;
using MovieDbAppByM.Mapping;

namespace MovieDbAppByM.DependencyInjection
{
    /// <summary>
    /// <see cref="Module"> managing injectable classes of <see cref="Mapping" /> namespace
    /// </summary>
    public class MappingModule : Module
    {
        /// <summary>
        /// <inheritdoc <see cref="Module"/> />
        /// </summary>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AutoMapperConfig>();

            base.Load(builder);
        }
    }
}
