using System.Windows.Input;

namespace MORM.Apresentacao.Commands
{
    public interface IAbstractCommand : ICommand { }
    public interface IAbstractFecharCommand : IAbstractCommand { }
    public interface IAbstractVoltarCommand : IAbstractCommand { }
    public interface IAbstractLimparCommand : IAbstractCommand { }
    public interface IAbstractListarCommand : IAbstractCommand { }
    public interface IAbstractConsultarCommand : IAbstractCommand { }
    public interface IAbstractSalvarCommand : IAbstractCommand { }
    public interface IAbstractExcluirCommand : IAbstractCommand { }
    public interface IAbstractExportarCommand : IAbstractCommand { }
    public interface IAbstractImportarCommand : IAbstractCommand { }
    public interface IAbstractImprimirCommand : IAbstractCommand { }
}