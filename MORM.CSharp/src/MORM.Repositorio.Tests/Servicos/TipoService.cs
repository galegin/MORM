using MORM.Dominio.Interfaces;
using MORM.Servico.Services;

namespace MORM.Repositorio.Tests
{
    public class TipoService : AbstractService<TipoModel>, ITipoService
    {
        public TipoService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}