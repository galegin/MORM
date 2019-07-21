using MORM.Apresentacao.Commands;

namespace MORM.Apresentacao
{
    public interface IMainCommand
    {
        AbstractCommand GetCommand<TEntrada, TRetorno>(CommandTipo tipo) 
            where TEntrada : class
            where TRetorno : class;
    }
}