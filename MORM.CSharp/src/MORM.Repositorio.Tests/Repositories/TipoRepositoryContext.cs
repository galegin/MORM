using MORM.Dominio.Interfaces;
using MORM.Repositorio.Repositories;

namespace MORM.Repositorio.Tests
{
    public class TipoRepositoryContext : Repository<TipoModel>, ITipoRepositoryContext
    {
        public TipoRepositoryContext(IAbstractDataContext dataContext) : base(dataContext)
        {
        }
    }
}