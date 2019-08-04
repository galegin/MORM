using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Servico.Interfaces;

namespace MORM.Servico.Services
{
    public class GrupoEmpresaAppService : AbstractAppService<GrupoEmpresa>, IGrupoEmpresaAppService
    {
        public GrupoEmpresaAppService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}