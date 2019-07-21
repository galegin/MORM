using MORM.Apresentacao.Commands.Tela;

namespace MORM.Apresentacao.Commands
{
    public class MainCommand : IMainCommand
    {
        public AbstractCommand GetCommand<TEntrada, TRetorno>(CommandTipo tipo)
            where TEntrada : class
            where TRetorno : class
        {
            switch (tipo)
            {
                case CommandTipo.Alterar:
                    return new AlterarTela<TEntrada>();
                case CommandTipo.Listar:
                    return new ListarTela<TEntrada, TRetorno>();
                case CommandTipo.Consultar:
                    return new ConsultarTela<TEntrada, TRetorno>();
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
    }
}