using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class ProdutoValorService : AbstractService<ProdutoValor>, IProdutoValorService
    {
        public ProdutoValorService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}