using MORM.Apresentacao.Commands;

namespace MORM.Apresentacao
{
    public interface IMainCommand
    {
        AbstractCommand GetCommand<TModel>(CommandTipo tipo)
            where TModel : class;
    }
}