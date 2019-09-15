using MORM.Repositorio.Dapper.Context;
using MORM.Repositorio.Repositories;

namespace MORM.Repositorio.Tests
{
    public class TipoRepositoryDapper : Repository<TipoModel>, ITipoRepositoryDapper
    {
        public TipoRepositoryDapper(IAbstractDataContextDapper dataContext) : base(dataContext)
        {
        }
    }
}