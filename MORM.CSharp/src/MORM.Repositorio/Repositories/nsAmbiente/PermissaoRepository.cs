using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;

namespace MORM.Repositorio.Repositories
{
    public class PermissaoRepository : Repository<Permissao>, IPermissaoRepository
    {
        public PermissaoRepository(IAbstractDataContext dataContext) : base(dataContext)
        {
        }
    }
}