using MORM.Repositorio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Repositorio.Extensions
{
    //-- galeg - 09/06/2018 11:04:33
    public static class FiltroExtension
    {
        public static void AddFiltro<TObject>(this List<string> where, string name, IComando comando, 
            List<TObject> lista, TObject inicial, TObject final)
        {
            if (lista != null && lista.Any())
                where.Add($"{name} in ({string.Join(",", lista.ConvertAll(x => comando.GetValueStr(x)))})");

            if (inicial != null)
            {
                var valueInicial = comando.GetValueStr(inicial);
                if (!valueInicial.Equals("null"))
                    where.Add($"{name} >= {valueInicial}");
            }

            if (final != null)
            {
                var valueFinal = comando.GetValueStr(final);
                if (!valueFinal.Equals("null"))
                    where.Add($"{name} <= {valueFinal}");
            }
        }
    }
}