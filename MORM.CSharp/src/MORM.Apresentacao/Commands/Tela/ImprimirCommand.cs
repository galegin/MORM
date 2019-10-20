using MORM.CrossCutting;
using System.ComponentModel;

namespace MORM.Apresentacao
{
    [Description("Imprimir")]
    public class ImprimirCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;
            var connector = vm.ElementType.GetImprimirConnector();

            var report = AbstractReport.GetReport(/*vm.Lista*/);
            if (report == null)
                return;

            var conteudo = connector.Imprimir(report) as string;
            if (string.IsNullOrWhiteSpace(conteudo))
                return;

            DialogsMessages.ImpressaoEfetuadaComSucesso.GetMensagem();
        }
    }
}