using System.Threading.Tasks;

namespace MovieDbAppByM.Persistance.UnitOfWork
{
    /// <summary>
    /// Unit of work contract.
    /// </summary>
    public interface IUnitOfWork
    {
        void Complete();
    }
}
