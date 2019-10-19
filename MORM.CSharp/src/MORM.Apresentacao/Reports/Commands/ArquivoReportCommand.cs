using MORM.CrossCutting;

namespace MORM.Apresentacao
{
    public class ArquivoReportCommand : AbstractCommand
    {
        #region metodos
        public override void Execute(object parameter)
        {
            var vm = parameter as AbstractReportViewModel;
            vm.ReportModel.Arquivo = DialogUtils.GetSaveFile(
                fileName: ReportsMessages.FileName,
                filter: ReportsMessages.Filters,
                defaultExt: ReportsMessages.DefaultExt);
        }
        #endregion
    }
}