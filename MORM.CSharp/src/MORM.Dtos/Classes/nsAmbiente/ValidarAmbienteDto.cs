using MORM.Dominio.Atributos;
using MORM.Dominio.Entidades;

namespace MORM.Dtos
{
    public abstract class ValidarAmbienteDto
    {
        [URL("Ambiente/Validar")]
        public class Envio
        {
            public string Login { get; set; }
            public string Senha { get; set; }
        }

        public class Retorno
        {
            public string Token { get; set; }
            public Ambiente Ambiente { get; set; }
        }
    }
}