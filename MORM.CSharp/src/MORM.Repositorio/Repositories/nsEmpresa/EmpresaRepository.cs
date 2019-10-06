using MORM.CrossCutting;

namespace MORM.Repositorio
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(IAbstractDataContext dataContext) : base(dataContext)
        {
        }
    }
}