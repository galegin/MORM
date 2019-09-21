using MORM.Dominio.Interfaces;
using MORM.Servico.Interfaces;

namespace MORM.Servico.Services
{
    public class MigracaoAppService : IMigracaoAppService
    {
        private readonly IMigracaoEntRepository _migracaoRepository;

        public MigracaoAppService(IMigracaoEntRepository migracaoRepository)
        {
            _migracaoRepository = migracaoRepository;
        }
    }
}