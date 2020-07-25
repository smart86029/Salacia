using System.Threading.Tasks;

namespace Salacia.Common.Domain
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}