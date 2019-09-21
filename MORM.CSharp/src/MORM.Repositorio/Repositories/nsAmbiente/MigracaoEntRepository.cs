using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;

namespace MORM.Repositorio.Repositories
{
    public class MigracaoEntRepository : Repository<MigracaoEnt>, IMigracaoEntRepository
    {
        public MigracaoEntRepository(IAbstractDataContext dataContext) : base(dataContext)
        {
        }
    }
}