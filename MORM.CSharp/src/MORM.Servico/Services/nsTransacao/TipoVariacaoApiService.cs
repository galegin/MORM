using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class TipoVariacaoApiService : AbstractApiService<TipoVariacao>, ITipoVariacaoApiService
    {
        public TipoVariacaoApiService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}