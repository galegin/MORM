using MORM.Apresentacao.Commands;

namespace MORM.Apresentacao.Reports
{
    public class ConfirmarReportCommand : AbstractCommand
    {
        #region metodos
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractReportViewModel;
            vm.ReportModel.Validate();
            vm.ConfirmarAction.Invoke();
        }
        #endregion
    }
}