using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;

namespace MORM.Repositorio.Repositories
{
    public class AmbienteRepository : Repository<Ambiente>, IAmbienteRepository
    {
        public AmbienteRepository(IAbstractDataContext dataContext) : base(dataContext)
        {
        }
    }
}