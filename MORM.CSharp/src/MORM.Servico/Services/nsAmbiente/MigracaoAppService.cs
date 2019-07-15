using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Servico.Interfaces;

namespace MORM.Servico.Services
{
    public class MigracaoAppService : AbstractService<MigracaoEnt>, IMigracaoAppService
    {
        public MigracaoAppService(IAbstractUnityOfWork abstractUnityOfWork) : base(abstractUnityOfWork)
        {
        }
    }
}