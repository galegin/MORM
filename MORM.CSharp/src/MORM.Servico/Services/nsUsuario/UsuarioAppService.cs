using MORM.Dominio.Interfaces;
using MORM.Servico.Interfaces;

namespace MORM.Servico.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioAppService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
    }
}