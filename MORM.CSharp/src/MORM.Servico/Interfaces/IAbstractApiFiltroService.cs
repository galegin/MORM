using MORM.Dtos;

namespace MORM.Servico.Interfaces
{
    public interface IAbstractApiFiltroService<TObject, TFiltro> : IAbstractApiService<TObject>
        where TObject : class
        where TFiltro : class
    {
        IAbstractApiService<TObject> ApiService { get; }
        AbstractApiFiltroDto<TObject, TFiltro>.ListarRet Listar(AbstractApiFiltroDto<TObject, TFiltro>.Listar dto);
    }
}