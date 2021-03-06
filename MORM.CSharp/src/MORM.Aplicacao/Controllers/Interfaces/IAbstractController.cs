using MORM.CrossCutting;

namespace MORM.Aplicacao
{
    public interface IAbstractController<TObject> where TObject : class
    {
        object Listar(/*TObject*/ FilterObjeto filtro);
        object Consultar(/*TObject*/ FilterObjeto filtro);
        object Incluir(TObject objeto);
        object Alterar(TObject objeto);
        object Salvar (TObject objeto);
        object Excluir(TObject objeto);
        object Sequencia(TObject filtro);
    }
}