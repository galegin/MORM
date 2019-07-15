using MORM.Dominio.Atributos;

namespace MORM.Servico.Models
{
    public abstract class AbstractSalvarDto
    {
        [MTD("Salvar")]
        public class Envio<TObject>
        {
            public TObject Objeto { get; set; }

            public Envio() { }
            public Envio(TObject filtro) => Objeto = filtro;
        }

        public class Validation
        {
        }
    }
}