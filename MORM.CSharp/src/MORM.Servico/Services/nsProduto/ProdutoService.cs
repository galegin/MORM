using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class ProdutoService : AbstractService<Produto>, IProdutoService
    {
        public ProdutoService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}