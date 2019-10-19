namespace MORM.Apresentacao.Report
{
    public class RelatorioDelimitador : IRelatorioDelimitador
    {
        public RelatorioDelimitador(string inicial, string entre, string final, string quebra, string traco, string branco)
        {
            Inicial = inicial;
            Entre = entre;
            Final = final;
            Quebra = quebra;
            Traco = traco;
            Branco = branco;
        }

        public string Inicial { get; }
        public string Entre { get; }
        public string Final { get; }
        public string Quebra { get; }
        public string Traco { get; }
        public string Branco { get; }
    }
}