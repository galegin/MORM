using MORM.CrossCutting;

namespace MORM.Repositorio
{
    public class LogAcessoRepository : Repository<LogAcesso>, ILogAcessoRepository
    {
        public LogAcessoRepository(IAbstractDataContext dataContext) : base(dataContext)
        {
        }
    }
}