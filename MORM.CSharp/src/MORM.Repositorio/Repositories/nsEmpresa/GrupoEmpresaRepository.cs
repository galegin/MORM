using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;

namespace MORM.Repositorio.Repositories
{
    public class GrupoEmpresaRepository : Repository<GrupoEmpresa>, IGrupoEmpresaRepository
    {
        public GrupoEmpresaRepository(IAbstractDataContext dataContext) : base(dataContext)
        {
        }
    }
}