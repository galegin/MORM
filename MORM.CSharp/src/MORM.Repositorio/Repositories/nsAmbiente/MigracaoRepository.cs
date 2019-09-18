using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;

namespace MORM.Repositorio.Repositories
{
    public class MigracaoRepository : Repository<MigracaoEnt>, IMigracaoRepository
    {
        public MigracaoRepository(IAbstractDataContext dataContext) : base(dataContext)
        {
        }
    }
}