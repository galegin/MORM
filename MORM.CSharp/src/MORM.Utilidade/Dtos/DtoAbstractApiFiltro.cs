using System;

namespace MORM.Utilidade.Dtos
{
    public class DtoAbstractApiFiltro<TObject, TFiltro> : DtoAbstractApi<TObject>
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