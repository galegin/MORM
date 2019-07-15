using MORM.Dominio.Interfaces;
using MORM.Servico.Services;

namespace MORM.Infra.Data.Tests
{
    public class TesteService : AbstractService<TesteModel>, ITesteService
    {
        public TesteService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}