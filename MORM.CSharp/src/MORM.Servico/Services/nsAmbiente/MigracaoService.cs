using MORM.Repositorio.Uow;
using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Servico.Interfaces.nsAmbiente;

namespace MORM.Servico.Services.nsAmbiente
{
    public class MigracaoService : AbstractService<Migracao>, IMigracaoService
    {
        public MigracaoService(IAbstractUnityOfWork abstractUnityOfWork) : base(abstractUnityOfWork)
        {
        }

        public MigracaoService(IAmbiente ambiente) : base(ambiente)
        {
        }
    }
}