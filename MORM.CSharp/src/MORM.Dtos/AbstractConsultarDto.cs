using MORM.Dominio.Atributos;

namespace MORM.Dtos
{
    public abstract class AbstractConsultarDto
    {
        [URL("Consultar")]
        public class Envio
        {
        }

        public class Retorno
        {
        }

        public class Validation
        {

        }
    }
}