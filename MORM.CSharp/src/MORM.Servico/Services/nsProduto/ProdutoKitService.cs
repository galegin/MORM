using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class ProdutoKitService : AbstractService<ProdutoKit>, IProdutoKitService
    {
        public ProdutoKitService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}