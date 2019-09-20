using MORM.CrossCutting;
using System;

namespace MORM.Servico.Models
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
            if (string.IsNullOrWhiteSpace(model.Ambiente))
                throw new Exception(_mensagemUsuarioDeveSerInformado);
            if (string.IsNullOrWhiteSpace(model.Login))
                throw new Exception(_mensagemUsuarioDeveSerInformado);
            if (string.IsNullOrWhiteSpace(model.Senha))
                throw new Exception(_mensagemSenhaDeveSerInformada);
        }
    }
}