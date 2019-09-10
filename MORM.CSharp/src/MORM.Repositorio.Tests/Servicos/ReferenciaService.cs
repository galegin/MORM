using MORM.Dominio.Interfaces;
using MORM.Servico.Services;

namespace MORM.Repositorio.Tests
{
    public class ReferenciaService : AbstractService<ReferenciaModel>, IReferenciaService
    {
        public ReferenciaService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}