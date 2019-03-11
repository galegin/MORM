using MORM.Apresentacao.Commands.Tela;

namespace MORM.Apresentacao.Commands.Manutencao
{
    public class AbstractProdutoListaCommand : AbstractListaCommand, IAbstractProdutoListaCommand
    {
        public AbstractProdutoListaCommand() : base(
            new FecharTela(),
            new AbstractProdutoLimparCommand(),
            new AbstractProdutoListarCommand())
        {
        }
    }

    public class AbstractProdutoManutCommand : AbstractManutCommand, IAbstractProdutoManutCommand
    {
        public AbstractProdutoManutCommand() : base(
            new FecharTela(),
            new AbstractProdutoLimparCommand(),
            new AbstractProdutoConsultarCommand(),
            new AbstractProdutoSalvarCommand(),
            new AbstractProdutoExcluirCommand())
        {
        }
    }

    #region command
    public class AbstractProdutoLimparCommand : AbstractLimparCommand { }
    public class AbstractProdutoListarCommand : AbstractListarCommand { }
    public class AbstractProdutoConsultarCommand : AbstractConsultarCommand { }
    public class AbstractProdutoSalvarCommand : AbstractSalvarCommand { }
    public class AbstractProdutoExcluirCommand : AbstractExcluirCommand { }
    #endregion
}