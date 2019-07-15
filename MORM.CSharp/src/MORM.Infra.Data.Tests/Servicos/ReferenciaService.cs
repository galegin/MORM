using MORM.Dominio.Interfaces;
using MORM.Servico.Services;

namespace MORM.Infra.Data.Tests
{
    public class ReferenciaService : AbstractService<ReferenciaModel>, IReferenciaService
    {
        public ReferenciaService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}