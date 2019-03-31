using MORM.Dominio.Atributos;

namespace MORM.Dtos
{
    public abstract class AbstractListarDto
    {
        [URL("Listar")]
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