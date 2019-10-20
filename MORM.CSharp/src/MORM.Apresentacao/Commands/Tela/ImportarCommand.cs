using MORM.CrossCutting;
using System.Collections;
using System.ComponentModel;

namespace MORM.Apresentacao
{
    [Description("Importar")]
    public class ImportarCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;
            var connector = vm.ElementType.GetSalvarConnector();

            var arquivo = DialogUtils.GetOpenFile(
                fileName: ExportsMessages.FileName,
                filter: ExportsMessages.Filters,
                defaultExt: ExportsMessages.DefaultExt);
            if (string.IsNullOrWhiteSpace(arquivo))
                return;

            var conteudo = ArquivoDiretorio.CarregarArquivo(arquivo);
            if (string.IsNullOrWhiteSpace(conteudo))
                return;

            var exports = vm.ElementType.GetExports();
            var lista = exports.GetListaFromExport(conteudo, arquivo);
            if (lista == null)
                return;

            vm.Lista = null;
            vm.Lista = lista as IList;

            foreach (var item in lista)
                connector.Salvar(item);

            DialogsMessages.ImportacaoEfetuadaComSucesso.GetMensagem();
        }
    }
}