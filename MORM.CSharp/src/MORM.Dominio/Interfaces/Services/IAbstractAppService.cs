namespace MORM.Dominio.Interfaces
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
        object Listar(TObject filtro);
        object Consultar(TObject filtro);
        object Incluir(TObject objeto);
        object Alterar(TObject objeto);
        object Salvar(TObject objeto);
        object Excluir(TObject objeto);
        object Sequencia(TObject filtro);
    }
}