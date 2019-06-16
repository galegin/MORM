using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class RegraFiscalService : AbstractService<RegraFiscal>, IRegraFiscalService
    {
        public RegraFiscalService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}