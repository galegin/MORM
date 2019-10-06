using MORM.CrossCutting;
using MORM.Servico.Interfaces;

namespace MORM.Servico.Services
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