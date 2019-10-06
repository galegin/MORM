using MORM.CrossCutting;

namespace MORM.Repositorio.Tests
{
    public class TipoRepositoryContext : Repository<TipoModel>, ITipoRepositoryContext
    {
        public TipoRepositoryContext(IAbstractDataContext dataContext) : base(dataContext)
        {
        }
    }
}