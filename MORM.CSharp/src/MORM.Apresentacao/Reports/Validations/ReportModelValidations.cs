using MORM.CrossCutting;

namespace MORM.Apresentacao
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
            Check.NotEmpty(model.Arquivo, ReportsMessages.InformeOArquivo);
        }

        private static void ValidateEmail(this ReportModel model)
        {
            Check.NotEmpty(model.Email, ReportsMessages.InformeOEmail);
            model.Email.ValidarEmail();
        }
        #endregion
    }
}