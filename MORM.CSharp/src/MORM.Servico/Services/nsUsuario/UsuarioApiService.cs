using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class UsuarioApiService : AbstractApiService<Usuario>, IUsuarioApiService
    {
        public UsuarioApiService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}