namespace MORM.Apresentacao
{
    public class CancelarReportCommand : AbstractCommand
    {
        #region metodos
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractReportViewModel;
            vm.FecharTela();
        }
        #endregion
    }
}