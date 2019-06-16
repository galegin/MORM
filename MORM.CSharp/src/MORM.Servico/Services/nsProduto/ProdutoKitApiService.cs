using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class ProdutoKitApiService : AbstractApiService<ProdutoKit>, IProdutoKitApiService
    {
        public ProdutoKitApiService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}