using MORM.CrossCutting;

namespace MORM.Repositorio
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IAbstractDataContext dataContext) : base(dataContext)
        {
        }
    }
}