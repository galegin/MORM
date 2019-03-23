using MORM.Dtos;
using System.Net.Http;

namespace MORM.Aplicacao.Controllers
{
    public interface IAbstractController<TObject> where TObject : class
    {
        HttpResponseMessage Listar(DtoAbstractApi<TObject>.Listar dto);
        HttpResponseMessage Consultar(DtoAbstractApi<TObject>.Consultar dto);
        HttpResponseMessage Incluir(DtoAbstractApi<TObject>.Incluir dto);
        HttpResponseMessage IncluirLista(DtoAbstractApi<TObject>.IncluirLista dto);
        HttpResponseMessage Alterar(DtoAbstractApi<TObject>.Alterar dto);
        HttpResponseMessage AlterarLista(DtoAbstractApi<TObject>.AlterarLista dto);
        HttpResponseMessage Salvar(DtoAbstractApi<TObject>.Salvar dto);
        HttpResponseMessage SalvarLista(DtoAbstractApi<TObject>.SalvarLista dto);
        HttpResponseMessage Excluir(DtoAbstractApi<TObject>.Excluir dto);
        HttpResponseMessage ExcluirLista(DtoAbstractApi<TObject>.ExcluirLista dto);
    }
}