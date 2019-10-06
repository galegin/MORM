using MORM.CrossCutting;

namespace MORM.Repositorio
{
    public class PermissaoRepository : Repository<Permissao>, IPermissaoRepository
    {
        public PermissaoRepository(IAbstractDataContext dataContext) : base(dataContext)
        {
        }
    }
}