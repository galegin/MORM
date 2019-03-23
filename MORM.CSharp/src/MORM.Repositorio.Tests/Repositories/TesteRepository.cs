using MORM.Repositorio.Interfaces;
using MORM.Repositorio.Repositories;

namespace MORM.Repositorio.Tests
{
    public class TesteRepository : AbstractRepository<TesteModel>, ITesteRepository
    {
        public TesteRepository(IAbstractDataContext context) : base(context)
        {
        }
    }
}