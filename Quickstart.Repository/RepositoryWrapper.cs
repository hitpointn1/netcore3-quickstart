using Quickstart.Repository.Context;
using Quickstart.Repository.Implementation;
using Quickstart.Repository.RepositoryInterfaces;
using System.Threading.Tasks;

namespace Quickstart.Repository
{
    public partial class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ApplicationContext _repoContext;
        public RepositoryWrapper(ApplicationContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        private ITestRepository _testRepository;
        public ITestRepository Test
        {
            get
            {
                if (_testRepository == null)
                {
                    _testRepository = new TestRepository(_repoContext);
                }

                return _testRepository;
            }
        }

        public async ValueTask SaveAsync()
        {
           await _repoContext.SaveChangesAsync();
        }
    }
}
