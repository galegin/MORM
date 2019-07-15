using MORM.Apresentacao.Report.Tipagens;

namespace MORM.Apresentacao.Report.Interfaces
{
    public interface IRelatorioCampo
    {
        string Codigo { get; set; }
        string Descricao { get; set; }
        int Tamanho { get; set; }
        int Precisao { get; set; }
        RelatorioAlinhamento Alinhamento { get; set; }
    }
}