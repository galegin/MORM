using MORM.Repositorio.Dapper;

namespace MORM.Repositorio.Tests
{
    public class TipoRepositoryContextDapper : Repository<TipoModel>, ITipoRepositoryContextDapper
    {
        public TipoRepositoryContextDapper(IAbstractDataContextDapper dataContext) : base(dataContext)
        {
        }
    }
}