using MORM.Apresentacao.Comps;

namespace MORM.Apresentacao.Reports
{
    public partial class AbstractReport : AbstractUserControl
    {
        private AbstractReport()
        {
            InitializeComponent();
            var vm = new AbstractReportViewModel();
            vm.ConfirmarAction = OnConfirmar;
            vm.CloseAction = OnCancelar;
            DataContext = vm;
        }

        private void OnConfirmar()
        {
            InConfirmado = true;
            btnFechar_Click(null, null);
        }

        private void OnCancelar()
        {
            InConfirmado = false;
            btnFechar_Click(null, null);
        }

        public static ReportModel GetReport(ReportModel model = null)
        {
            var userControl = new AbstractReport();
            var vm = userControl.DataContext as AbstractReportViewModel;
            vm.SetReportInModel(model);
            if (TelaUtils.Instance.AbrirDialog(userControl) ?? true && userControl.InConfirmado)
                return vm.GetReportModel();
            return null;
        }
    }
}