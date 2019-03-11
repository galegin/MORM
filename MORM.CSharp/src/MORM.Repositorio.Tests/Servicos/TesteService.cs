using MORM.Repositorio.IoC;
using MORM.Repositorio.Services;
using MORM.Utilidade.Interfaces;

namespace MORM.Repositorio.Tests
{
    //-- galeg - 31/03/2018 13:19:06
    public class TesteService : AbstractService<TesteModel>, ITesteService
    {
        public TesteService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }

        public TesteService(IAmbiente ambiente) : base(ambiente)
        {

        }
    }
}