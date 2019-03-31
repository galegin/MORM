using MORM.Dtos;
using System.Net.Http;

namespace MORM.WebApi.Controllers
{
    public interface IAbstractController<TObject> where TObject : class
    {
        HttpResponseMessage Listar(AbstractApiDto<TObject>.Listar dto);
        HttpResponseMessage Consultar(AbstractApiDto<TObject>.Consultar dto);
        HttpResponseMessage Incluir(AbstractApiDto<TObject>.Incluir dto);
        HttpResponseMessage Alterar(AbstractApiDto<TObject>.Alterar dto);
        HttpResponseMessage Salvar(AbstractApiDto<TObject>.Salvar dto);
        HttpResponseMessage Excluir(AbstractApiDto<TObject>.Excluir dto);
    }
}