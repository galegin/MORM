using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class OperacaoApiService : AbstractApiService<Operacao>, IOperacaoApiService
    {
        public OperacaoApiService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}