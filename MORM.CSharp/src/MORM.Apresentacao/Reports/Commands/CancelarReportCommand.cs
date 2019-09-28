using MORM.Apresentacao.Commands;

namespace MORM.Apresentacao.Reports
{
    public class CancelarReportCommand : AbstractCommand
    {
        #region metodos
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractReportViewModel;
            vm.CloseAction.Invoke();
        }
        #endregion
    }
}