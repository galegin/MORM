using System.Net.Http;

namespace MORM.Aplicacao.Controllers
{
    public interface IAbstractController<TObject> where TObject : class
    {
        HttpResponseMessage Listar(TObject filtro);
        HttpResponseMessage Consultar(TObject filtro);
        HttpResponseMessage Incluir(TObject objeto);
        HttpResponseMessage Alterar(TObject objeto);
        HttpResponseMessage Salvar (TObject objeto);
        HttpResponseMessage Excluir(TObject objeto);
        HttpResponseMessage Sequencia(TObject filtro);
    }
}