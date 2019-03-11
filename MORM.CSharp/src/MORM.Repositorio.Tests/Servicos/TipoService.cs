using MORM.Repositorio.IoC;
using MORM.Repositorio.Services;
using MORM.Utilidade.Interfaces;

namespace MORM.Repositorio.Tests
{
    //-- galeg - 31/03/2018 13:19:06
    public class TipoService : AbstractService<TipoModel>, ITipoService
    {
        public TipoService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }

        public TipoService(IAmbiente ambiente) : base(ambiente)
        {
        }
    }
}