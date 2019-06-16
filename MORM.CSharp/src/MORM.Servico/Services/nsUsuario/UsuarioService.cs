using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class UsuarioService : AbstractService<Usuario>, IUsuarioService
    {
        public UsuarioService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}