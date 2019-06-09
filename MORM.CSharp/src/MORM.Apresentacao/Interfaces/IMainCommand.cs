using MORM.Apresentacao.Commands;

namespace MORM.Apresentacao
{
    public interface IMainCommand
    {
        AbstractCommand GetCommand<TEntrada>(CommandTipo tipo);
        AbstractCommand GetCommandLista<TEntrada, TRetorno>(CommandTipo tipo);
    }
}