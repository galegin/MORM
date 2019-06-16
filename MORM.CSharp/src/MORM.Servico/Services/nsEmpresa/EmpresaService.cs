using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class EmpresaService : AbstractService<Empresa>, IEmpresaService
    {
        public EmpresaService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}