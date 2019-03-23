using MORM.Dominio.Atributos;
using MORM.Dominio.Entidades;

namespace MORM.Dtos.nsAmbiente
{
    public class AmbienteDto
    {
        [URL("Ambiente/ValidarAcesso")]
        public class ValidarAcesso
        {
        }

        public class ValidarAcessoRetorno
        {
            public string Token { get; set; }
            public Ambiente Ambiente { get; set; }
        }
    }
}