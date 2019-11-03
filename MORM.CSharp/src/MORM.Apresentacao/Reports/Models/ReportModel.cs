namespace MORM.Apresentacao
{
    public class ReportModel : AbstractModel
    {
        #region variaveis
        private ReportTipo _tipo;
        private string _arquivo;
        private string _email;
        private string _impressora;
        #endregion

        #region propriedades
        public ReportTipo Tipo
        {
            get => _tipo;
            set => SetField(ref _tipo, value);
        }
        public string Arquivo
        {
            get => _arquivo;
            set => SetField(ref _arquivo, value);
        }
        public string Email
        {
            get => _email;
            set => SetField(ref _email, value);
        }
        public string Impressora
        {
            get => _impressora;
            set => SetField(ref _impressora, value);
        }
        #endregion
    }

    public static class ReportModelExtensions
    {
        public static void SetTipo(this ReportModel model, bool isSetar, ReportTipo tipo)
        {
            if (isSetar)
                model.Tipo = tipo;
        }
    }
}