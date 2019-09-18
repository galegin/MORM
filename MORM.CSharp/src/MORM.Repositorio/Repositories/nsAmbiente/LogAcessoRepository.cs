using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;

namespace MORM.Repositorio.Repositories
{
    public class LogAcessoRepository : Repository<LogAcesso>, ILogAcessoRepository
    {
        public LogAcessoRepository(IAbstractDataContext dataContext) : base(dataContext)
        {
        }
    }
}