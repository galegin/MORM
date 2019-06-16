using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class GrupoEmpresaService : AbstractService<GrupoEmpresa>, IGrupoEmpresaService
    {
        public GrupoEmpresaService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}