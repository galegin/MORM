using MORM.CrossCutting;

namespace MORM.Servico
{
    public class EmpresaAppService : AbstractAppService<Empresa>, IEmpresaAppService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaAppService(IEmpresaRepository empresaRepository) : base(empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }
    }
}