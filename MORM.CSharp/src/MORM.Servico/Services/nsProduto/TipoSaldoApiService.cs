using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class TipoSaldoApiService : AbstractApiService<TipoSaldo>, ITipoSaldoApiService
    {
        public TipoSaldoApiService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}