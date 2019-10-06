using MORM.CrossCutting;

namespace MORM.Servico
{
    public class UsuarioAppService : AbstractAppService<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioAppService(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
    }
}