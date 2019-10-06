using MORM.CrossCutting;

namespace MORM.Servico
{
    public class GrupoEmpresaAppService : AbstractAppService<GrupoEmpresa>, IGrupoEmpresaAppService
    {
        private readonly IGrupoEmpresaRepository _grupoEmpresaRepository;

        public GrupoEmpresaAppService(IGrupoEmpresaRepository grupoEmpresaRepository) : base(grupoEmpresaRepository)
        {
            _grupoEmpresaRepository = grupoEmpresaRepository;
        }
    }
}