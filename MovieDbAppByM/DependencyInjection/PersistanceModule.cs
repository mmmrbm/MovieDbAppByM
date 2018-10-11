using Autofac;
using MovieDbAppByM.Persistance;

namespace MovieDbAppByM.DependencyInjection
{
    /// <summary>
    /// <see cref="Module"> managing injectable classes of <see cref="Persistance" /> namespace
    /// </summary>
    public class PersistanceModule : Module
    {
        /// <summary>
        /// <inheritdoc <see cref="Module"/> />
        /// </summary>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MovieAppDbContext>().SingleInstance();
            base.Load(builder);
        }
    }
}
