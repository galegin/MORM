using MORM.Dominio.Atributos;

namespace MORM.Servico.Models
{
    public abstract class AbstractExcluirDto
    {
        [MTD("Excluir")]
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