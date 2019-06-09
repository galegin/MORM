using MORM.Apresentacao.Commands.Tela;

namespace MORM.Apresentacao.Commands
{
    public class MainCommand : IMainCommand
    {
        public AbstractCommand GetCommand<TEntrada>(CommandTipo tipo)
        {
            switch (tipo)
            {
                case CommandTipo.Alterar:
                    return new AlterarTela<TEntrada>();
                case CommandTipo.Consultar:
                    return new ConsultarTela<TEntrada>();
                case CommandTipo.Excluir:
                    return new ExcluirTela<TEntrada>();
                case CommandTipo.Exportar:
                    return new ExportarTela<TEntrada>();
                case CommandTipo.Importar:
                    return new ImportarTela<TEntrada>();
                case CommandTipo.Imprimir:
                    return new ImprimirTela<TEntrada>();
                case CommandTipo.Incluir:
                    return new IncluirTela<TEntrada>();
                case CommandTipo.Limpar:
                    return new LimparTela<TEntrada>();
                case CommandTipo.Salvar:
                    return new AlterarTela<TEntrada>();
            }

            return null;
        }

        public AbstractCommand GetCommandLista<TEntrada, TRetorno>(CommandTipo tipo)
        {
            switch (tipo)
            {
                case CommandTipo.Listar:
                    return new ListarTela<TEntrada, TRetorno>();
            }

            return null;
        }
    }
}