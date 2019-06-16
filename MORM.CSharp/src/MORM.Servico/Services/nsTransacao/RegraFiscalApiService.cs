using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class RegraFiscalApiService : AbstractApiService<RegraFiscal>, IRegraFiscalApiService
    {
        public RegraFiscalApiService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}