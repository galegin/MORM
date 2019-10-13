using MORM.CrossCutting;

namespace MORM.Servico
{
    [URL("Ambiente/Validar")]
    public class ValidarAmbienteInModel
    {
        public string Ambiente { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }

    public static class ValidarAmbienteInModelValidation
    {
        private const string _mensagemAmbienteDeveSerInformado = "Ambiente deve ser informado";
        private const string _mensagemUsuarioDeveSerInformado = "Usuario deve ser informado";
        private const string _mensagemSenhaDeveSerInformada = "Senha deve ser informada";

        public static void Validate(this ValidarAmbienteInModel model)
        {
            Check.NotEmpty(model.Ambiente, _mensagemAmbienteDeveSerInformado);
            Check.NotEmpty(model.Login, _mensagemUsuarioDeveSerInformado);
            Check.NotEmpty(model.Senha, _mensagemSenhaDeveSerInformada);
        }
    }
}