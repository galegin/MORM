using MORM.Dominio.Atributos;
using System.Collections.Generic;

namespace MORM.Dtos
{
    public abstract class AbstractListarDto
    {
        [MTD("Listar")]
        public class Envio<TObject>
        {
            public TObject Filtro { get; set; }
            public int QtdeRegistro { get; set; }
            public int NumeroPagina { get; set; }

            public Envio() { }
            public Envio(TObject filtro) => Filtro = filtro;
        }

        public class Retorno<TObject>
        {
            public List<TObject> Lista { get; set; }

            public Retorno() { }
            public Retorno(List<TObject> lista) => Lista = lista;
        }

        public class Validation
        {
        }
    }
}