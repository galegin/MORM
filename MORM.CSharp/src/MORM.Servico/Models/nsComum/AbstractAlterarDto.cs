using MORM.Dominio.Atributos;

namespace MORM.Servico.Models
{
    public abstract class AbstractAlterarDto
    {
        [MTD("Alterar")]
        public class Envio<TObject>
        {
            public TObject Objeto { get; set; }

            public Envio() { }
            public Envio(TObject objeto) => Objeto = objeto;
        }

        public class Validation
        {
        }
    }
}