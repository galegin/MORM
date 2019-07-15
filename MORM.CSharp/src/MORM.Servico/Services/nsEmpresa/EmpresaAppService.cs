using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Servico.Interfaces;

namespace MORM.Servico.Services
{
    public class EmpresaAppService : AbstractAppService<Empresa>, IEmpresaAppService
    {
        public EmpresaAppService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}