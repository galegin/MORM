using MORM.Dominio.Interfaces;
using MORM.Servico.Interfaces;

namespace MORM.Servico.Services
{
    public class GrupoEmpresaAppService : IGrupoEmpresaAppService
    {
        private readonly IGrupoEmpresaRepository _grupoEmpresaRepository;

        public GrupoEmpresaAppService(IGrupoEmpresaRepository grupoEmpresaRepository)
        {
            _grupoEmpresaRepository = grupoEmpresaRepository;
        }
    }
}