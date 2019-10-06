using MORM.CrossCutting;

namespace MORM.Repositorio
{
    public class GrupoEmpresaRepository : Repository<GrupoEmpresa>, IGrupoEmpresaRepository
    {
        public GrupoEmpresaRepository(IAbstractDataContext dataContext) : base(dataContext)
        {
        }
    }
}