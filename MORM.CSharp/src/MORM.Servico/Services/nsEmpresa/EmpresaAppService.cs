using MORM.Dominio.Interfaces;
using MORM.Servico.Interfaces;

namespace MORM.Servico.Services
{
    public class EmpresaAppService : IEmpresaAppService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaAppService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

    }
}