using MORM.Dominio.Interfaces;
using MORM.Servico.Services;

namespace MORM.Repositorio.Tests
{
    public class TesteService : AbstractService<TesteModel>, ITesteService
    {
        public TesteService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}