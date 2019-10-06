using MORM.CrossCutting;

namespace MORM.Servico
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