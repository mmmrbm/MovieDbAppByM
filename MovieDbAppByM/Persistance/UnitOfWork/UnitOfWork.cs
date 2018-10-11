namespace MovieDbAppByM.Persistance.UnitOfWork
{
    /// <summary>
    /// Implementation of <see cref="IUnitOfWork">
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private MovieAppDbContext movieAppDbContext = null;

        public UnitOfWork(MovieAppDbContext movieAppDbContext)
        {
            this.movieAppDbContext = movieAppDbContext;
        }

        public void Complete()
        {
            movieAppDbContext.SaveChanges();
        }
    }
}
