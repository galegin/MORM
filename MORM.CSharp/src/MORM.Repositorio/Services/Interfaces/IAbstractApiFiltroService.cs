using MORM.Utilidade.Dtos;

namespace MORM.Repositorio.Services
{
    //-- galeg - 01/05/2018 11:38:32
    public interface IAbstractApiFiltroService<TObject, TFiltro> : IAbstractApiService<TObject>
        where TObject : class
        where TFiltro : class
    {
        DtoAbstractApiFiltro<TObject, TFiltro>.ListarRet Listar(DtoAbstractApiFiltro<TObject, TFiltro>.Listar dto);
    }
}