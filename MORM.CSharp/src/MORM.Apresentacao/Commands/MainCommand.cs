using MORM.Apresentacao.Commands.Tela;
using System;
using System.Collections.Generic;

namespace MORM.Apresentacao.Commands
{
    public class MainCommand : IMainCommand
    {
        private static Dictionary<CommandTipo, Type> _commands =
            new Dictionary<CommandTipo, Type>
            {
                { CommandTipo.Fechar, typeof(FecharCommand) },
                { CommandTipo.Voltar, typeof(VoltarTelaAnteriorCommand) },

                { CommandTipo.Limpar, typeof(LimparCommand) },
                { CommandTipo.Listar, typeof(ListarCommand) },
                { CommandTipo.Consultar, typeof(ConsultarCommand) },

                { CommandTipo.Incluir, typeof(IncluirCommand) },
                { CommandTipo.Alterar, typeof(AlterarCommand) },
                { CommandTipo.Salvar, typeof(SalvarCommand) },
                { CommandTipo.Excluir, typeof(ExcluirCommand) },

                { CommandTipo.Exportar, typeof(ExportarCommand) },
                { CommandTipo.Importar, typeof(ImportarCommand) },

                { CommandTipo.Imprimir, typeof(ImprimirCommand) },

                { CommandTipo.Retornar, typeof(RetornarCommand) },
                { CommandTipo.Selecionar, typeof(SelecionarCommand) },

                { CommandTipo.Confirmar, typeof(ConfirmarCommand) },
                { CommandTipo.Cancelar, typeof(CancelarCommand) },

                { CommandTipo.InverterSelecao, typeof(InverterSelecaoCommand) },
                { CommandTipo.SelecionarTodos, typeof(SelecionarTodosCommand) },
            };

        public AbstractCommand GetCommand(CommandTipo tipo)
        {
            var typeCommand = _commands.ContainsKey(tipo) ? _commands[tipo] : null;
            return typeCommand != null ? Activator.CreateInstance(typeCommand) as AbstractCommand : null;
        }
    }

    public static class MainCommandExtensions
    {
        public static IMainCommand GetMainCommand(this Type classe)
        {
            return new MainCommand();
        }
    }
}