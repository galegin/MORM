using MORM.Dtos;
using System.Net.Http;

namespace MORM.WebApi.Controllers
{
    public interface IAbstractControllerFiltro<TObject, TFiltro> : IAbstractController<TObject>
        where TObject : class
        where TFiltro : class
    {
        HttpResponseMessage ListarFiltro(AbstractApiFiltroDto<TObject, TFiltro>.Listar dto);
    }
}