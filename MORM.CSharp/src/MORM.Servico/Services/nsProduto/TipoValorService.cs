using MORM.Dominio.Entidades;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Services
{
    public class TipoValorService : AbstractService<TipoValor>, ITipoValorService
    {
        public TipoValorService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }
    }
}