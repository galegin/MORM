using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class TipoVariacaoMotivoService : AbstractService<TipoVariacaoMotivo>, ITipoVariacaoMotivoService
    {
        public TipoVariacaoMotivoService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}