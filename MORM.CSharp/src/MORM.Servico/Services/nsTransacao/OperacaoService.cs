using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class OperacaoService : AbstractService<Operacao>, IOperacaoService
    {
        public OperacaoService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}