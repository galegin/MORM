using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class TipoValorApiService : AbstractApiService<TipoValor>, ITipoValorApiService
    {
        public TipoValorApiService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}