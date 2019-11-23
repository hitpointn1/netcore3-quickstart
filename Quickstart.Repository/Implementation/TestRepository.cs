using Quickstart.Repository.Context;
using Quickstart.Repository.Entities;
using Quickstart.Repository.RepositoryInterfaces;

namespace Quickstart.Repository.Implementation
{
    public class TestRepository : BaseRepository<Test>, ITestRepository
    {
        public TestRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
