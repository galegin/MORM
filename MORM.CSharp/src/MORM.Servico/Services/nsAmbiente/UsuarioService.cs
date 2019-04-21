using MORM.Repositorio.Uow;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces.nsAmbiente;

namespace MORM.Servico.Services.nsAmbiente
{
    public class UsuarioService : AbstractApiService<Usuario>, IUsuarioService
    {
        public UsuarioService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}