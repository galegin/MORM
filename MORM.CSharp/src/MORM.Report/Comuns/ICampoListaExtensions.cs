using MORM.Report.Classes;
using MORM.Report.Interfaces;
using MORM.Report.Tipagens;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Report.Comuns
{
    public static class ICampoListaExtensions
    {
        public static IList<IRelatorioCampo> GetRelatorioCampos(this IList<ICampoLista> camposLista)
        {
            var retorno = new List<IRelatorioCampo>();

            camposLista.ToList().ForEach(c =>
            {
                retorno.Add(
                    new RelatorioCampo(
                        codigo: c.Codigo,
                        descricao: c.Descricao,
                        tamanho: c.Tamanho,
                        precisao: c.Precisao,
                        alinhamento: (RelatorioAlinhamento)(int)c.Alinhamento));
            });

            return retorno;
        }
    }
}