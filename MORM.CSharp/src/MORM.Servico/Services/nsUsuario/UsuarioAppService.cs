using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Servico.Interfaces;

namespace MORM.Servico.Services
{
    public class UsuarioAppService : AbstractAppService<Usuario>, IUsuarioAppService
    {
        public UsuarioAppService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}