using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.ViewsModel;
using MORM.CrossCutting;
using System.ComponentModel;

namespace MORM.Apresentacao.Commands.Tela
{
    [Description("Exportar")]
    public class ExportarTela<TModel> : AbstractCommand
        where TModel : class
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel<TModel>;
            var connector = new AbstractExportarConnector<TModel>();

            var arquivo = DialogUtils.GetSaveFile(
                fileName: ExportsMessages.FileName,
                filter: ExportsMessages.Filters,
                defaultExt: ExportsMessages.DefaultExt);
            if (string.IsNullOrWhiteSpace(arquivo))
                return;

            var conteudo = connector.Executar(vm.ObjModel, filtro: arquivo) as string;
            if (string.IsNullOrWhiteSpace(conteudo))
                return;

            ArquivoDiretorio.GravarArquivo(arquivo, conteudo);

            DialogsMessages.ArquivoExportadoComSucesso.GetMensagem();
        }
    }
}