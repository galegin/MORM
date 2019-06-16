using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class TipoVariacaoMotivoApiService : AbstractApiService<TipoVariacaoMotivo>, ITipoVariacaoMotivoApiService
    {
        public TipoVariacaoMotivoApiService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}