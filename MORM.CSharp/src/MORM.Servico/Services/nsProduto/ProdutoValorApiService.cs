using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class ProdutoValorApiService : AbstractApiService<ProdutoValor>, IProdutoValorApiService
    {
        public ProdutoValorApiService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}