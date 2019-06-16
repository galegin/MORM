using MORM.Repositorio.Uow;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;

namespace MORM.Servico.Services
{
    public class MigracaoEntService : AbstractService<MigracaoEnt>, IMigracaoEntService
    {
        public MigracaoEntService(IAbstractUnityOfWork abstractUnityOfWork) : base(abstractUnityOfWork)
        {
        }
    }
}