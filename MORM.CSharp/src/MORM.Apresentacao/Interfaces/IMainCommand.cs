using MORM.Apresentacao.Commands;
using MORM.CrossCutting;
using System;

namespace MORM.Apresentacao
{
    public interface IMainCommand
    {
        AbstractCommand GetCommand(CommandTipo tipo);
    }
}