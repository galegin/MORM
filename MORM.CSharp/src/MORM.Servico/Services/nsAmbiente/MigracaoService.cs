using MORM.Repositorio.Uow;
using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces.nsAmbiente;

namespace MORM.Servico.Services.nsAmbiente
{
    public class MigracaoService : AbstractService<MigracaoEnt>, IMigracaoService
    {
        public MigracaoService(IAbstractUnityOfWork abstractUnityOfWork) : base(abstractUnityOfWork)
        {
        }
    }
}