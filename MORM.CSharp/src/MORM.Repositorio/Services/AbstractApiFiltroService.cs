using MORM.Repositorio.IoC;
using MORM.Utilidade.Dtos;
using MORM.Utilidade.Interfaces;

namespace MORM.Repositorio.Services
{
    //-- galeg - 01/05/2018 11:14:23
    public class AbstractApiFiltroService<TObject, TFiltro> : AbstractApiService<TObject>, IAbstractApiFiltroService<TObject, TFiltro> 
        where TObject : class
        where TFiltro : class
    {
        public AbstractApiFiltroService(IAbstractUnityOfWork abstractUnityOfWork) : base(abstractUnityOfWork)
        {
        }

        public AbstractApiFiltroService(IAmbiente ambiente) : base(ambiente)
        {
        }

        //-- listar

        public DtoAbstractApiFiltro<TObject, TFiltro>.ListarRet Listar(DtoAbstractApiFiltro<TObject, TFiltro>.Listar dto)
        {
            return new DtoAbstractApi<TObject>.ListarRet(AbstractRepository.ListarO(dto.Filtro, 
                qtde: dto.QtdeRegistro, pagina: dto.NumeroPagina));
        }
    }
}