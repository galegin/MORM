using MORM.CrossCutting;

namespace MORM.Repositorio
{
    public class MigracaoEntRepository : Repository<MigracaoEnt>, IMigracaoEntRepository
    {
        public MigracaoEntRepository(IAbstractDataContext dataContext) : base(dataContext)
        {
        }
    }
}