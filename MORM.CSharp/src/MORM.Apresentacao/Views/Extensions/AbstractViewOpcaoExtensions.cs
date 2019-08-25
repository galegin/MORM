using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Controls;
using MORM.Apresentacao.ViewsModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MORM.Apresentacao.Views
{
    public static class AbstractViewOpcaoExtensions
    {
        public static void OnHabilitarOpcao(this IAbstractViewModel vm, AbstractOpcao opcao,
            bool isExibirConsulta, bool isExibirCadastro, 
            bool isExibirFiltro, bool isExibirRelatorio)
        {
            var mainCommand = vm.ElementType.GetMainCommand();

            var commands = new List<ICommand>
            {
                mainCommand.GetCommand(CommandTipo.Voltar),
                mainCommand.GetCommand(CommandTipo.Limpar),

                isExibirConsulta ? mainCommand.GetCommand(CommandTipo.Listar) : null,
                isExibirConsulta ? mainCommand.GetCommand(CommandTipo.Exportar) : null,
                isExibirConsulta ? mainCommand.GetCommand(CommandTipo.Importar) : null,
                isExibirConsulta || isExibirRelatorio ? mainCommand.GetCommand(CommandTipo.Imprimir) : null,

                isExibirCadastro ? mainCommand.GetCommand(CommandTipo.Consultar) : null,
                isExibirCadastro ? mainCommand.GetCommand(CommandTipo.Salvar) : null,
                isExibirCadastro ? mainCommand.GetCommand(CommandTipo.Excluir) : null,

                isExibirFiltro ? mainCommand.GetCommand(CommandTipo.Confirmar) : null,
                isExibirFiltro ? mainCommand.GetCommand(CommandTipo.Cancelar) : null,
            }
            .Where(c => c != null)
            .ToArray()
            ;

            opcao.CreateComps(commands);
        }
    }
}