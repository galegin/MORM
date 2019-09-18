using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;

namespace MORM.Repositorio.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IAbstractDataContext dataContext) : base(dataContext)
        {
        }
    }
}