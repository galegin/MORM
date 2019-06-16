using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class ProdutoBarraService : AbstractService<ProdutoBarra>, IProdutoBarraService
    {
        public ProdutoBarraService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}