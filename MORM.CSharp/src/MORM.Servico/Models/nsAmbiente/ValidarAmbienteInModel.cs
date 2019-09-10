using MORM.CrossCutting;

namespace MORM.Servico.Models
{
    [URL("Ambiente/Validar")]
    public class ValidarAmbienteInModel
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}