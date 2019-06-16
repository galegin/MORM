using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class PessoaApiService : AbstractApiService<Pessoa>, IPessoaApiService
    {
        public PessoaApiService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}