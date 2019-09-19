using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Servico.Interfaces;

namespace MORM.Servico.Services
{
    public class GrupoEmpresaAppService : AbstractAppService<GrupoEmpresa>, IGrupoEmpresaAppService
    {
        private readonly IGrupoEmpresaRepository _grupoEmpresaRepository;

        public GrupoEmpresaAppService(IGrupoEmpresaRepository grupoEmpresaRepository) :base(grupoEmpresaRepository)
        {
            _grupoEmpresaRepository = grupoEmpresaRepository;
        }
    }
}