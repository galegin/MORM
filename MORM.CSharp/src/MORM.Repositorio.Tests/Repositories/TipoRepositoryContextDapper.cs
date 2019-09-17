using MORM.Repositorio.Dapper.Context;
using MORM.Repositorio.Repositories;

namespace MORM.Repositorio.Tests
{
    public class TipoRepositoryContextDapper : Repository<TipoModel>, ITipoRepositoryContextDapper
    {
        public TipoRepositoryContextDapper(IAbstractDataContextDapper dataContext) : base(dataContext)
        {
        }
    }
}