namespace MORM.Apresentacao.Commands
{
    public interface IAbstractListaCommand : IAbstractFormCommand
    {
        IAbstractLimparCommand Limpar { get; }
        IAbstractListarCommand Listar { get; }
    }
}