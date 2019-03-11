using MORM.Repositorio.Interfaces;
using MORM.Repositorio.Repositories;

namespace MORM.Repositorio.Tests
{
    //-- galeg - 01/10/2018 19:47:11
    public class TesteRepository : AbstractRepository<TesteModel>, ITesteRepository
    {
        public TesteRepository(IAbstractDataContext context) : base(context)
        {
        }
    }
}