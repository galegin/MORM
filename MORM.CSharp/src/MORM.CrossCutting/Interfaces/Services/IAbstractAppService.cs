namespace MORM.CrossCutting
{
    public interface IAbstractAppService
    {
        void SetAmbiente(IAmbiente ambiente);
    }

    public interface IAbstractAmbAppService
    {
    }

    public interface IAbstractAppService<TObject> : IAbstractAppService where TObject : class
    {
        object Listar(object filtro);
        object Consultar(object filtro);
        object Incluir(TObject objeto);
        object Alterar(TObject objeto);
        object Salvar(TObject objeto);
        object Excluir(TObject objeto);
        object Sequenciar(object filtro);
    }
}