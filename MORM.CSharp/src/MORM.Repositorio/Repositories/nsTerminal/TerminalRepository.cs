using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;

namespace MORM.Repositorio.Repositories
{
    public class TerminalRepository : Repository<Terminal>, ITerminalRepository
    {
        public TerminalRepository(IAbstractDataContext dataContext) : base(dataContext)
        {
        }
    }
}