using MORM.CrossCutting;
using System.ComponentModel;

namespace MORM.Apresentacao
{
    [Description("Exportar")]
    public class ExportarCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;

            var arquivo = DialogUtils.GetSaveFile(
                fileName: ExportsMessages.FileName,
                filter: ExportsMessages.Filters,
                defaultExt: ExportsMessages.DefaultExt);
            if (string.IsNullOrWhiteSpace(arquivo))
                return;

            var exports = vm.ElementType.GetExports();
            var conteudo = exports.GetExport(vm.Lista, arquivo);
            if (string.IsNullOrWhiteSpace(conteudo))
                return;

            ArquivoDiretorio.GravarArquivo(arquivo, conteudo);

            DialogsMessages.ExportacaoEfetuadaComSucesso.GetMensagem();
        }
    }
}