using MORM.Dominio.Interfaces;
using MORM.Repositorio.Repositories;

namespace MORM.Repositorio.Tests
{
    public class TipoRepository : AbstractRepository<TipoModel>, ITipoRepository
    {
        public TipoRepository(IAbstractDataContext context) : base(context)
        {
        }
    }
}