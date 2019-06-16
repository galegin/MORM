using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class BairroService : AbstractService<Bairro>, IBairroService
    {
        public BairroService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}