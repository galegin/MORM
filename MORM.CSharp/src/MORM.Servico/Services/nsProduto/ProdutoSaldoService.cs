using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class ProdutoSaldoService : AbstractService<ProdutoSaldo>, IProdutoSaldoService
    {
        public ProdutoSaldoService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}