using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class TransacaoService : AbstractService<Transacao>, ITransacaoService
    {
        public TransacaoService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}