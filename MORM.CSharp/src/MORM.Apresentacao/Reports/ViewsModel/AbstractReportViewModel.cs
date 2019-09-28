using MORM.Apresentacao.ViewsModel;
using MORM.CrossCutting;
using System;
using System.Collections.Generic;

namespace MORM.Apresentacao.Reports
{
    public class AbstractReportViewModel : AbstractViewModel
    {
        #region variaveis
        private ReportModel _reportModel;
        #endregion

        #region propriedades
        public ReportModel ReportModel
        {
            get => _reportModel;
            set => SetField(ref _reportModel, value);
        }
        public IEnumerable<object> ReportTipos => 
            EnumExtensions.GetEnum<ReportTipo>();
        public string ReportTipoStr
        {
            get => _reportModel.Tipo.ToString();
            set
            {
                Enum.TryParse(value, true, out ReportTipo reportTipo);
                _reportModel.Tipo = reportTipo;
                NotifyPropertyChanged();
                IsArquivo = reportTipo.IsArquivo();
                IsEmail = reportTipo.IsEmail();
            }
        }
        public bool IsArquivo
        {
            get => ReportModel.Tipo.IsArquivo();
            set
            {
                ReportModel.SetTipo(value, ReportTipo.ExportarParaArquivo);
                NotifyPropertyChanged();
            }
        }
        public bool IsEmail
        {
            get => ReportModel.Tipo.IsEmail();
            set
            {
                ReportModel.SetTipo(value, ReportTipo.EnviarPorEmail);
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region comandos
        public ArquivoReportCommand Arquivo { get; }
        public ConfirmarReportCommand Confirmar { get; }
        public CancelarReportCommand Cancelar { get; }
        #endregion

        #region construtores
        public AbstractReportViewModel()
        {
            ReportModel = new ReportModel();
            Arquivo = new ArquivoReportCommand();
            Confirmar = new ConfirmarReportCommand();
            Cancelar = new CancelarReportCommand();
        }
        #endregion

        #region metodos
        public ReportModel GetReportModel()
        {
            var reportModel = new ReportModel();
            reportModel.CloneInstancePropOrFieldAll(ReportModel);
            return reportModel;
        }

        public void SetReportInModel(ReportModel reportModel)
        {
            if (reportModel == null)
                return;

            ReportModel.CloneInstancePropOrFieldAll(reportModel);
        }
        #endregion
    }
}