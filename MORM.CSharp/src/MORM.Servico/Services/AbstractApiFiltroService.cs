using MORM.Dominio.Interfaces;
using MORM.Dtos;
using MORM.Repositorio.Services;
using MORM.Repositorio.Uow;
using MORM.Servico.Interfaces;

namespace MORM.Servico.Services
{
    public class AbstractApiFiltroService<TObject, TFiltro> : 
        AbstractApiService<TObject>, IAbstractApiFiltroService<TObject, TFiltro> 
        where TObject : class
        where TFiltro : class
    {
        public AbstractApiFiltroService(IAbstractUnityOfWork abstractUnityOfWork) : base(abstractUnityOfWork)
        {
        }

        public AbstractApiFiltroService(IAmbiente ambiente) : base(ambiente)
        {
        }

        public IAbstractApiService<TObject> ApiService => this;

        //-- listar

        public AbstractApiFiltroDto<TObject, TFiltro>.ListarRet Listar(AbstractApiFiltroDto<TObject, TFiltro>.Listar dto)
        {
            return new AbstractApiDto<TObject>.ListarRet(AbstractRepository.ListarO(dto.Filtro, 
                qtde: dto.QtdeRegistro, pagina: dto.NumeroPagina));
        }
    }
}