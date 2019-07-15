using System;
using System.Collections.Generic;

namespace MORM.Aplicacao.Doc
{
    public class GeradorDoc
    {
        private readonly GerarDoctoCs _gerarDoctoCs;
        private readonly GerarDoctoCsv _gerarDoctoCsv;
        private readonly GerarDoctoJson _gerarDoctoJson;
        private readonly GerarDoctoTxt _gerarDoctoTxt;

        public GeradorDoc()
        {
            _gerarDoctoCs = new GerarDoctoCs();
            _gerarDoctoCsv = new GerarDoctoCsv();
            _gerarDoctoJson = new GerarDoctoJson();
            _gerarDoctoTxt = new GerarDoctoTxt();
        }

        /// <summary>
        /// gerador de documentação de classes
        /// ex.:
        ///     var listaDeClasse = new Dictionary<string, Type>
        ///     {
        ///         { "Transacao", typeof(TraTransacao) },
        ///         { "Fiscal", typeof(FisNf) },
        ///         { "Financeiro", typeof(FgrLiq) },
        ///         { "Receber", typeof(FcrFaturac) },
        ///         { "Pessoa", typeof(PesPessoa) },
        ///         { "Produto", typeof(PrdProduto) },
        ///         { "Caixa", typeof(FcxCaixac) }
        ///     };
        ///     new GeradorDoc().Gerar(listaDeClasse);
        /// </summary>
        /// <param name="listaDeClasse"></param>
        public void Gerar(Dictionary<string, Type> listaDeClasse)
        {
            Console.WriteLine("Gerando documentacao");

            foreach (var classe in listaDeClasse)
            {
                Console.Write("  " + classe.Key + "... ");

                _gerarDoctoCs.Gerar(classe.Key, classe.Value);
                _gerarDoctoCsv.Gerar(classe.Key, classe.Value);
                _gerarDoctoJson.Gerar(classe.Key, classe.Value);
                _gerarDoctoTxt.Gerar(classe.Key, classe.Value);

                Console.WriteLine("OK");
            }

            Console.WriteLine("Documentacao gerada com sucesso");
            Console.ReadLine();
        }
    }
}