using MORM.Apresentacao.Report.Interfaces;
using MORM.Dominio.Extensions;
using System.Collections;
using System.Collections.Generic;
using MORM.Apresentacao.Report.Tipagens;

namespace MORM.Apresentacao.Report.Extensoes
{
    public static class RelatorioExtensions
    {  
        public static RelatorioFormato GetFormato(this IRelatorio relatorio, 
            RelatorioFormato? formato = null)
        {
            return formato ?? relatorio.Formato ?? RelatorioFormato.Txt;
        }

        public static string GetNomeImpressora(this IRelatorio relatorio, string nomeImpressora = null)
        {
            return nomeImpressora ?? relatorio.NomeImpressora;
        }

        public static string GetNomeArquivo(this IRelatorio relatorio, string nomeArquivo = null)
        {
            return nomeArquivo ?? relatorio.NomeArquivo;
        }

        //-- exportacao

        private static IRelatorio _relatorio;
        private static RelatorioFormato _formato;
        private static IRelatorioDelimitador _delimitador;

        private static int _larguraRelatorio => _relatorio.Largura ?? 0;
        private static int _larguraDisponivel => _larguraRelatorio -
                (_delimitador.Inicial.Length + _delimitador.Final.Length);

        public static string[] GetConteudoExportacao(this IRelatorio relatorio, 
            RelatorioFormato? formato = null, int? larguraRelatorio = null)
        {
            _relatorio = relatorio;
            _formato = formato ?? relatorio.Formato ?? RelatorioFormato.Txt;
            _delimitador = _formato.GetDelimitador();

            var conteudos = new List<string>();

            InserirLinhaTracejada(conteudos);

            foreach (var parte in relatorio.Partes)
            {
                var conteudosParte = parte.GetConteudoExportacao();

                foreach (var conteudo in conteudosParte)
                {
                    conteudos.Add(conteudo);
                    InserirLinhaEmBranco(conteudos);
                    InserirLinhaTracejada(conteudos);
                }
            }

            return conteudos.ToArray();
        }

        //-- linha branco

        private static void InserirLinhaEmBranco(List<string> conteudos)
        {
            if (!_formato.IsLinhaEmBranco() || string.IsNullOrEmpty(_delimitador.Branco) || _larguraRelatorio <= 0)
                return;
            var conteudo = _delimitador.Branco.PadLeft(_larguraDisponivel, _delimitador.Branco[0]);
            conteudos.Add(conteudo.GetConteudoLinha());
        }

        //-- linha tracejada

        private static void InserirLinhaTracejada(List<string> conteudos)
        {
            if (!_formato.IsLinhaTracejada() || string.IsNullOrEmpty(_delimitador.Traco) || _larguraRelatorio <= 0)
                return;
            var conteudo = _delimitador.Traco.PadLeft(_larguraDisponivel, _delimitador.Traco[0]);
            conteudos.Add(conteudo.GetConteudoLinha());
        }

        //-- conteudo

        private static string GetConteudoLinha(this string linha)
        {
            return $"{_delimitador.Inicial}{linha}{_delimitador.Final}";
        }

        //-- parte

        private static string[] GetConteudoExportacao(this IRelatorioParte relatorioParte)
        {
            switch (relatorioParte.Tipo)
            {
                case RelatorioParteTipo.Cabecalho:
                    return relatorioParte.GetConteudoCabecalho();
                case RelatorioParteTipo.Titulo:
                    return relatorioParte.GetConteudoTitulo();

                case RelatorioParteTipo.Corpo:
                    return relatorioParte.GetConteudoCorpo();
                case RelatorioParteTipo.Quebra:
                    return relatorioParte.GetConteudoQuebra();
                case RelatorioParteTipo.TituloColunas:
                    return relatorioParte.GetConteudoTituloColunas();
                default:
                case RelatorioParteTipo.Detalhe:
                    return relatorioParte.GetConteudoDetalhe();
                case RelatorioParteTipo.SubTotal:
                    return relatorioParte.GetConteudoSubTotal();
                case RelatorioParteTipo.Total:
                    return relatorioParte.GetConteudoTotal();

                case RelatorioParteTipo.Sumario:
                    return relatorioParte.GetConteudoSumario();
                case RelatorioParteTipo.Rodape:
                    return relatorioParte.GetConteudoRodape();
            }
        }

        //-- cabecalho

        private static string[] GetConteudoCabecalho(this IRelatorioParte relatorioParte)
        {
            var conteudos = new List<string>();

            foreach (var campo in relatorioParte.Campos)
            {
                if (campo.Tamanho <= 0)
                    campo.Tamanho = _larguraDisponivel;

                var value = relatorioParte.Objeto.GetInstancePropOrField(campo.Codigo);
                var conteudo = campo.GetValue(_formato, value);
                conteudos.Add(conteudo.GetConteudoLinha());
            }

            return conteudos.ToArray();
        }

        //-- titulo

        private static string[] GetConteudoTitulo(this IRelatorioParte relatorioParte)
        {
            return relatorioParte.GetConteudoCabecalho();
        }

        //-- corpo

        private static string[] GetConteudoCorpo(this IRelatorioParte relatorioParte)
        {
            var conteudos = new List<string>();

            foreach (var parte in relatorioParte.Partes)
            {
                var conteudosParte = parte.GetConteudoExportacao();
                foreach (var conteudoParte in conteudosParte)
                {
                    conteudos.Add(conteudoParte);
                }
            }

            return conteudos.ToArray();
        }

        //-- quebra

        private static string[] GetConteudoQuebra(this IRelatorioParte relatorioParte)
        {
            var conteudos = new List<string>();
            var conteudo = new List<string>();

            foreach (var campo in relatorioParte.Campos)
            {
                var value = relatorioParte.Objeto.GetInstancePropOrField(campo.Codigo);
                conteudo.Add($"{campo.Descricao}: {campo.GetValue(_formato, value)}");
            }

            conteudos.Add(string.Join(_delimitador.Quebra, conteudo).GetConteudoLinha());

            foreach (var parteQuebra in relatorioParte.Partes)
            {
                var conteudosQuebra = parteQuebra.GetConteudoExportacao();
                foreach (var conteudoQuebra in conteudosQuebra)
                    conteudos.Add(conteudoQuebra);
            }

            return conteudos.ToArray();
        }

        //-- titulo colunas

        private static string[] GetConteudoTituloColunas(this IRelatorioParte relatorioParte)
        {
            var conteudos = new List<string>();
            var conteudo = new List<string>();

            foreach (var campo in relatorioParte.Campos)
            {
                conteudo.Add($"{campo.GetDescicao(_formato)}");
            }

            conteudos.Add(string.Join(_delimitador.Entre, conteudo).GetConteudoLinha());

            return conteudos.ToArray();
        }

        //-- detalhe

        private static string[] GetConteudoDetalhe(this IRelatorioParte relatorioParte)
        {
            var conteudos = new List<string>();
            var conteudo = new List<string>();
            var objetos = new List<object>();

            if (relatorioParte.Objeto is IList)
            {
                foreach (var objeto in (relatorioParte.Objeto as IList))
                    objetos.Add(objeto);
            }
            else
            {
                objetos.Add(relatorioParte.Objeto);
            }

            foreach (var objeto in objetos)
            {
                foreach (var campo in relatorioParte.Campos)
                {
                    var value = objeto.GetInstancePropOrField(campo.Codigo);
                    conteudo.Add($"{campo.GetValue(_formato, value)}");
                }
            }

            conteudos.Add(string.Join(_delimitador.Entre, conteudo).GetConteudoLinha());

            return conteudos.ToArray();
        }

        //-- subtotal e total

        private static string[] GetConteudoSubTotalTitulo(this IRelatorioParte relatorioParte, string titulo)
        {
            var conteudos = new List<string>();
            var conteudo = new List<string>();

            conteudo.Add(titulo);

            foreach (var campo in relatorioParte.Campos)
            {
                var value = relatorioParte.Objeto.GetInstancePropOrField(campo.Codigo);
                conteudo.Add($"{campo.Descricao}: {campo.GetValue(_formato, value)}");
            }

            conteudos.Add(string.Join(_delimitador.Entre, conteudo).GetConteudoLinha());

            return conteudos.ToArray();
        }

        private static string[] GetConteudoSubTotal(this IRelatorioParte relatorioParte)
        {
            return relatorioParte.GetConteudoSubTotalTitulo("SubTotal -> ");
        }

        //-- total

        private static string[] GetConteudoTotal(this IRelatorioParte relatorioParte)
        {
            return relatorioParte.GetConteudoSubTotalTitulo("Total -> ");
        }

        //-- sumario

        private static string[] GetConteudoSumario(this IRelatorioParte relatorioParte)
        {
            return relatorioParte.GetConteudoCabecalho();
        }

        //-- rodape

        private static string[] GetConteudoRodape(this IRelatorioParte relatorioParte)
        {
            return relatorioParte.GetConteudoCabecalho();
        }
    }
}