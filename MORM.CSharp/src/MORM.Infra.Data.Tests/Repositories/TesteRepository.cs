using MORM.Dominio.Interfaces;
using MORM.Infra.Data.Repositories;

namespace MORM.Infra.Data.Tests
{
    public class TesteRepository : AbstractRepository<TesteModel>, ITesteRepository
    {
        public TesteRepository(IAbstractDataContext context) : base(context)
        {
        }
    }
}