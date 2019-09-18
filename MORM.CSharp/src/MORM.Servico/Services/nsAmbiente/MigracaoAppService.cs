using MORM.Dominio.Interfaces;
using MORM.Servico.Interfaces;

namespace MORM.Servico.Services
{
    public class MigracaoAppService : IMigracaoAppService
    {
        private readonly IMigracaoRepository _migracaoRepository;

        public MigracaoAppService(IMigracaoRepository migracaoRepository)
        {
            _migracaoRepository = migracaoRepository;
        }
    }
}