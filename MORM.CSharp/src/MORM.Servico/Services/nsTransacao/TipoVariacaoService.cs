using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class TipoVariacaoService : AbstractService<TipoVariacao>, ITipoVariacaoService
    {
        public TipoVariacaoService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}