using MORM.Dominio.Atributos;

namespace MORM.Dtos
{
    public abstract class AbstractAlterarDto
    {
        [URL("Alterar")]
        public class Envio
        {
        }

        public class Validation
        {
        }
    }
}