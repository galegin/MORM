using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class GrupoEmpresaApiService : AbstractApiService<GrupoEmpresa>, IGrupoEmpresaApiService
    {
        public GrupoEmpresaApiService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}