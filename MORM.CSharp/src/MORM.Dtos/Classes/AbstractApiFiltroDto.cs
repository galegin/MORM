using System;

namespace MORM.Dtos
{
    public class AbstractApiFiltroDto<TObject, TFiltro> : AbstractApiDto<TObject>
        where TObject : class
        where TFiltro : class
    {
        new public class Listar
        {
            public Listar()
            {
            }

            public Listar(TFiltro filtro, int qtdeRegistro = -1, int numeroPagina = 0)
            {
                Filtro = filtro ?? throw new ArgumentNullException(nameof(filtro));
                QtdeRegistro = qtdeRegistro;
                NumeroPagina = numeroPagina;
            }

            public TFiltro Filtro { get; set; }
            public int QtdeRegistro { get; set; } = -1;
            public int NumeroPagina { get; set; } = 0;
        }
    }
}