using Autofac;
using MovieDbAppByM.Utility;

namespace MovieDbAppByM.DependencyInjection
{
    /// <summary>
    /// <see cref="Module"> managing injectable classes of <see cref="Utility" /> namespace
    /// </summary>
    public class UtilityModule : Module
    {
        /// <summary>
        /// <inheritdoc <see cref="Module"/> />
        /// </summary>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ImageFetchUtil>();
            builder.RegisterType<MovieInfoFetchUtil>();
            builder.RegisterType<MovieImageTypes>();

            base.Load(builder);
        }
    }
}
