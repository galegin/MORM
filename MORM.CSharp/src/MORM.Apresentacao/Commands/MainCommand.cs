using MORM.Apresentacao.Commands.Tela;

namespace MORM.Apresentacao.Commands
{
    public class MainCommand : IMainCommand
    {
        public AbstractCommand GetCommand<TModel>(CommandTipo tipo)
            where TModel : class
        {
            switch (tipo)
            {
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
            }

            return null;
        }
    }
}