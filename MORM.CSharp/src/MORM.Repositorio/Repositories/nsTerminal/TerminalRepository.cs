using MORM.CrossCutting;

namespace MORM.Repositorio
{
    public class TerminalRepository : Repository<Terminal>, ITerminalRepository
    {
        public TerminalRepository(IAbstractDataContext dataContext) : base(dataContext)
        {
        }
    }
}