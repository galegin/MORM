namespace MORM.Apresentacao.Report
{
    public interface IRelatorioDelimitador
    {
        string Inicial { get; }
        string Entre { get; }
        string Final { get; }
        string Quebra { get; }
        string Traco { get; }
        string Branco { get; }
    }
}