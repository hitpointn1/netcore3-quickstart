using Quickstart.Repository.RepositoryInterfaces;
using System.Threading.Tasks;

namespace Quickstart.Repository
{
    public interface IRepositoryWrapper
    {
        ITestRepository Test { get; }
        ValueTask SaveAsync();
    }
}
