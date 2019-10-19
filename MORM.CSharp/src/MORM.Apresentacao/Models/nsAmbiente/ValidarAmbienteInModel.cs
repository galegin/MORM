using MORM.CrossCutting;

namespace MORM.Apresentacao
{
    [URL("Ambiente/Validar")]
    public class ValidarAmbienteInModel
    {
        public string Ambiente { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}