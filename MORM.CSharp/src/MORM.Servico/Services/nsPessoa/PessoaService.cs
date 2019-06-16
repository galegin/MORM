using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class PessoaService : AbstractService<Pessoa>, IPessoaService
    {
        public PessoaService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}