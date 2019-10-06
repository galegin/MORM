using MORM.CrossCutting;

namespace MORM.Repositorio
{
    public class AmbienteRepository : Repository<Ambiente>, IAmbienteRepository
    {
        public AmbienteRepository(IAbstractDataContext dataContext) : base(dataContext)
        {
        }
    }
}