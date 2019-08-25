using MORM.Apresentacao.Commands.Tela;

namespace MORM.Apresentacao.Commands
{
    public abstract class MainCommand : IMainCommand
    {
        public abstract AbstractCommand GetCommand(CommandTipo tipo);
    }

    public class MainCommand<TModel> : MainCommand, IMainCommand<TModel>
        where TModel : class
    {
        public override AbstractCommand GetCommand(CommandTipo tipo)
        {
            switch (tipo)
            {
                case CommandTipo.Fechar:
                    return new FecharTela();
                case CommandTipo.Voltar:
                    return new VoltarTelaAnterior();

                case CommandTipo.Limpar:
                    return new LimparTela<TModel>();

                case CommandTipo.Listar:
                    return new ListarTela<TModel>();
                case CommandTipo.Consultar:
                    return new ConsultarTela<TModel>();

                case CommandTipo.Incluir:
                    return new IncluirTela<TModel>();
                case CommandTipo.Alterar:
                    return new AlterarTela<TModel>();
                case CommandTipo.Salvar:
                    return new SalvarTela<TModel>();
                case CommandTipo.Excluir:
                    return new ExcluirTela<TModel>();

                case CommandTipo.Exportar:
                    return new ExportarTela<TModel>();
                case CommandTipo.Importar:
                    return new ImportarTela<TModel>();

                case CommandTipo.Imprimir:
                    return new ImprimirTela<TModel>();

                case CommandTipo.Retornar:
                    return new RetornarTela<TModel>();
                case CommandTipo.Selecionar:
                    return new SelecionarTela<TModel>();

                case CommandTipo.Confirmar:
                    return new ConfirmarTela<TModel>();
                case CommandTipo.Cancelar:
                    return new CancelarTela<TModel>();

                case CommandTipo.InverterSelecao:
                    return new InverterSelecaoTela<TModel>();
                case CommandTipo.SelecionarTodos:
                    return new SelecionarTodosTela<TModel>();
            }

            return null;
        }
    }
}