using MORM.Dominio.Atributos;

namespace MORM.Dtos
{
    public abstract class AbstractConsultarDto
    {
        [MTD("Consultar")]
        public class Envio<TObject>
        {
            public TObject Filtro { get; set; }

            public Envio() { }
            public Envio(TObject filtro) => Filtro = filtro;
        }

        public class Retorno<TObject>
        {
            public TObject Objeto { get; set; }

            public Retorno() { }
            public Retorno(TObject objeto) => Objeto = objeto;
        }

        public class Validation
        {
        }
    }
}