using MORM.Dominio.Interfaces;
using MORM.Servico.Services;

namespace MORM.Infra.Data.Tests
{
    public class TipoService : AbstractService<TipoModel>, ITipoService
    {
        public TipoService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}