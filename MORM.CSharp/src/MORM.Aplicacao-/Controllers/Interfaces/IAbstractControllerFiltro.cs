using MORM.Dtos;
using System.Net.Http;

namespace MORM.Aplicacao.Controllers
{
    public interface IAbstractControllerFiltro<TObject, TFiltro> : IAbstractController<TObject>
        where TObject : class
        where TFiltro : class
    {
        HttpResponseMessage ListarFiltro(DtoAbstractApiFiltro<TObject, TFiltro>.Listar dto);
    }
}