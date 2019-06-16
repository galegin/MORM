using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class ProdutoBarraApiService : AbstractApiService<ProdutoBarra>, IProdutoBarraApiService
    {
        public ProdutoBarraApiService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}