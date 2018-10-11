using Autofac;
using MovieDbAppByM.Persistance.Repository.Contract;
using MovieDbAppByM.Persistance.Repository.Implementation;
using MovieDbAppByM.Persistance.UnitOfWork;

namespace MovieDbAppByM.DependencyInjection
{
    /// <summary>
    /// <see cref="Module"> managing injectable classes of <see cref="Repository" /> namespace
    /// </summary>
    public class RepositoryModule : Module
    {
        /// <summary>
        /// <inheritdoc <see cref="Module"/> />
        /// </summary>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ActorRepository>().As<IActorRepository>();
            builder.RegisterType<DirectorRepository>().As<IDirectorRepository>();
            builder.RegisterType<MovieActorRepository>().As<IMovieActorRepository>();
            builder.RegisterType<MovieDirectorRepository>().As<IMovieDirectorRepository>();
            builder.RegisterType<MovieRepository>().As<IMovieRepository>();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            base.Load(builder);
        }
    }
}
