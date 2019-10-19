using MORM.CrossCutting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MORM.Apresentacao
{
    public static class EsquemaTema
    {
        private static List<EsquemaCor> _listaEsquemaCor;

        public static List<EsquemaCor> GetListaEsquemaCor()
        {
            if (_listaEsquemaCor != null)
                return _listaEsquemaCor;

            var arquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "esquemacor.json");
            _listaEsquemaCor = JsonExtensions.GetListaFromJson<EsquemaCor>(arquivo, _esquemaPadrao.Replace("'", "\""));

            return _listaEsquemaCor;
        }

        public static EsquemaCor GetEsquema(this EsquemaTipo tipo)
        {
            return GetListaEsquemaCor()
                .FirstOrDefault(x => x.Tipo == tipo)
                ??
                new EsquemaCor
                {
                    Tipo = tipo,
                };
        }

        #region padrão
        private const string _esquemaPadrao = @"[
    {
        'Tipo':'Cabecalho',
        'CorFonte':'#FFFFFF',
        'CorFundo':'#395697',
        'IsItalico':false,
        'IsNegrito':false,
        'IsSublinhado':false,
        'TamFonte':16
    },
    {
        'Tipo':'Corpo',
        'CorFonte':'#000000',
        'CorFundo':'#FFFFFF',
        'IsItalico':false,
        'IsNegrito':false,
        'IsSublinhado':false,
        'TamFonte':16
    },
    {
        'Tipo':'Destaque',
        'CorFonte':'#FFFFFF',
        'CorFundo':'#000000',
        'IsItalico':false,
        'IsNegrito':false,
        'IsSublinhado':false,
        'TamFonte':16
    },
    {
        'Tipo':'Detalhe',
        'CorFonte':'#000000',
        'CorFundo':'#FFFFFF',
        'IsItalico':false,
        'IsNegrito':false,
        'IsSublinhado':false,
        'TamFonte':16
    },
    {
        'Tipo':'Menu',
        'CorFonte':'#FFFFFF',
        'CorFundo':'#000000',
        'IsItalico':false,
        'IsNegrito':false,
        'IsSublinhado':false,
        'TamFonte':16
    },
    {
        'Tipo':'Rodape',
        'CorFonte':'#000000',
        'CorFundo':'#888888',
        'IsItalico':false,
        'IsNegrito':false,
        'IsSublinhado':false,
        'TamFonte':16
    },
    {
        'Tipo':'Titulo',
        'CorFonte':'#FFFFFF',
        'CorFundo':'#395697',
        'IsItalico':false,
        'IsNegrito':false,
        'IsSublinhado':false,
        'TamFonte':16
    }
]";
        #endregion
    }
}