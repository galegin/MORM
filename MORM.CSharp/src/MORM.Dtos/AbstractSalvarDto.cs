using MORM.Dominio.Atributos;

namespace MORM.Dtos
{
    public abstract class AbstractSalvarDto
    {
        [URL("Salvar")]
        public class Envio
        {
        }

        public class Validation
        {
        }
    }
}