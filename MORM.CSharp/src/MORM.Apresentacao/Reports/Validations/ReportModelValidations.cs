using MORM.CrossCutting;
using System;

namespace MORM.Apresentacao.Reports
{
    public static class ReportModelValidations
    {
        #region metodos
        public static void Validate(this ReportModel model)
        {
            if (model.Tipo.IsArquivo())
                model.ValidateArquivo();
            if (model.Tipo.IsEmail())
                model.ValidateEmail();
        }

        private static void ValidateArquivo(this ReportModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Arquivo))
                throw new Exception(ReportsMessages.InformeOArquivo);
        }

        private static void ValidateEmail(this ReportModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Email))
                throw new Exception(ReportsMessages.InformeOEmail);

            model.Email.ValidarEmail();
        }
        #endregion
    }
}