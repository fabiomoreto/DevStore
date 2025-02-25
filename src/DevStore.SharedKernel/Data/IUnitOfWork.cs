using System.Threading.Tasks;

namespace DevStore.SharedKernel.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}