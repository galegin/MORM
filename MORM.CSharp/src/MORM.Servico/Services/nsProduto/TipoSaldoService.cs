using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class TipoSaldoService : AbstractService<TipoSaldo>, ITipoSaldoService
    {
        public TipoSaldoService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}