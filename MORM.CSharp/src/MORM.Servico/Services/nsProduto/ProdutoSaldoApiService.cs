using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class ProdutoSaldoApiService : AbstractApiService<ProdutoSaldo>, IProdutoSaldoApiService
    {
        public ProdutoSaldoApiService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}