using MORM.Repositorio.Uow;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces.nsAmbiente;

namespace MORM.Servico.Services.nsAmbiente
{
    public class EmpresaService : AbstractApiService<Empresa>, IEmpresaService
    {
        public EmpresaService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}