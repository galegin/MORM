using MORM.Apresentacao.Commands;
using MORM.Infra.CrossCutting;
using System;

namespace MORM.Apresentacao
{
    public interface IMainCommand
    {
        AbstractCommand GetCommand(CommandTipo tipo);
    }

    public interface IMainCommand<TModel> : IMainCommand
            where TModel : class
    {
    }

    public static class IMainCommandExtensions
    {
        public static IMainCommand GetMainCommand(this Type type)
        {
            return TypeForConvert.GetObjectFor(typeof(MainCommand<>), type) as IMainCommand;
        }
    }
}