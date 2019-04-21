using MORM.Dominio.Atributos;

namespace MORM.Dtos
{
    public abstract class AbstractSequenciaDto
    {
        [MTD("Sequencia")]
        public class Envio<TObject>
        {
            public TObject Filtro { get; set; }

            public Envio() { }
            public Envio(TObject filtro) => Filtro = filtro;
        }

        public class Validation
        {
        }
    }
}