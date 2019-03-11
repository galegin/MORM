namespace MORM.Apresentacao.Commands
{
    public interface IAbstractManutCommand : IAbstractFormCommand
    {
        IAbstractLimparCommand Limpar { get; }
        IAbstractConsultarCommand Consultar { get; }
        IAbstractSalvarCommand Salvar { get; }
        IAbstractExcluirCommand Excluir { get; }
    }
}