using System.Collections.Generic;
using System.Linq;

namespace MORM.Utils.Extensions
{
    public struct CampoDefinicao
    {
        public CampoDefinicao(string codigo, string descricao, int tamanho, int precisao)
        {
            Codigo = codigo;
            Descricao = descricao;
            Tamanho = tamanho;
            Precisao = precisao;
        }

        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int Tamanho { get; set; }
        public int Precisao { get; set; }
    }

    public static class CampoExtensions
    {
        private static CampoDefinicao[] _listaCampoDefinicao =
        {
            new CampoDefinicao("Cd", "Cód.", 10, 0),
            new CampoDefinicao("Ds", "Descr.", 60, 0),
            new CampoDefinicao("Dt", "Data", 10, 0),
            new CampoDefinicao("Dh", "Dt/Hr", 10, 0),
            new CampoDefinicao("Hr", "Hora", 10, 0),
            new CampoDefinicao("Id", "Id", 10, 0),
            new CampoDefinicao("In", "", 10, 0),
            new CampoDefinicao("Nm", "Nome", 60, 0),
            new CampoDefinicao("Nr", "Nro", 10, 0),
            new CampoDefinicao("Pr", "Perc.", 10, 0),
            new CampoDefinicao("Qt", "Qtde", 10, 3),
            new CampoDefinicao("Tp", "Tp.", 10, 3),
            new CampoDefinicao("U", "", 10, 0),
            new CampoDefinicao("Vl", "Valor", 10, 2),
        };

        private static Dictionary<string, string> _listaTraducao = new Dictionary<string, string>
        {
            { "cao", "ção" },
            { "zao", "zão" },
        };

        public static string GetPreFixo(this string campo)
        {
            return campo.Contains("_") ? campo.Split('_')[0] : campo;
        }

        public static string GetPosFixo(this string campo)
        {
            return campo.Contains("_") ? campo.Split('_')[1] : string.Empty;
        }

        public static CampoDefinicao? GetCampoDefinicao(this string campo)
        {
            var codigo = campo.GetPreFixo();
            return _listaCampoDefinicao.FirstOrDefault(x => x.Codigo == codigo);
        }

        public static string GetCodigo(this string campo)
        {
            return campo.GetCampoDefinicao()?.Codigo ?? campo;
        }

        public static string GetDescricao(this string campo)
        {
            return campo.GetCampoDefinicao()?.Descricao ?? campo;
        }

        public static int GetTamanho(this string campo)
        {
            return campo.GetCampoDefinicao()?.Tamanho ?? 10;
        }

        public static int GetPrecisao(this string campo)
        {
            return campo.GetCampoDefinicao()?.Precisao ?? 0;
        }

        public static string GetTraducao(this string campo)
        {
            var retorno = new List<string>();

            var preFixo = campo.GetDescricao();
            if (!string.IsNullOrWhiteSpace(preFixo))
                retorno.Add(preFixo);

            var posFixo = campo.GetPosFixo();
            if (!string.IsNullOrWhiteSpace(posFixo))
                retorno.Add(posFixo);

            var conteudo = string.Join(" ", retorno);

            foreach(var traducao in _listaTraducao)
                if (conteudo.Contains(traducao.Key))
                    conteudo = conteudo.Replace(traducao.Key, traducao.Value);

            return conteudo;
        }
    }
}