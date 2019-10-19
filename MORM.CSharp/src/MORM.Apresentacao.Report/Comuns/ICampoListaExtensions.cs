using System.Collections.Generic;
using System.Linq;

namespace MORM.Apresentacao.Report
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