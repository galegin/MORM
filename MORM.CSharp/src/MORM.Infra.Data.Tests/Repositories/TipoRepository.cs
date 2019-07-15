using MORM.Dominio.Interfaces;
using MORM.Infra.Data.Repositories;

namespace MORM.Infra.Data.Tests
{
    public class TipoRepository : AbstractRepository<TipoModel>, ITipoRepository
    {
        public TipoRepository(IAbstractDataContext context) : base(context)
        {
        }
    }
}