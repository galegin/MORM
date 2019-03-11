using MORM.Apresentacao.Commands.Tela;

namespace MORM.Apresentacao.Commands.Manutencao
{
    public class AbstractClienteListaCommand : AbstractListaCommand, IAbstractClienteListaCommand
    {
        public AbstractClienteListaCommand() : base(
            new FecharTela(),
            new AbstractClienteLimparCommand(),
            new AbstractClienteListarCommand())
        {
        }
    }

    public class AbstractClienteManutCommand : AbstractManutCommand, IAbstractClienteManutCommand
    {
        public AbstractClienteManutCommand() : base(
            new FecharTela(),
            new AbstractClienteLimparCommand(),
            new AbstractClienteConsultarCommand(),
            new AbstractClienteSalvarCommand(),
            new AbstractClienteExcluirCommand())
        {
        }
    }

    #region command
    public class AbstractClienteLimparCommand : AbstractLimparCommand { }
    public class AbstractClienteListarCommand : AbstractListarCommand { }
    public class AbstractClienteConsultarCommand : AbstractConsultarCommand {}
    public class AbstractClienteSalvarCommand : AbstractSalvarCommand { }
    public class AbstractClienteExcluirCommand : AbstractExcluirCommand { }
    #endregion
}