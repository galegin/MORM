using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class TransacaoApiService : AbstractApiService<Transacao>, ITransacaoApiService
    {
        public TransacaoApiService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}